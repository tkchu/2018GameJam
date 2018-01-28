using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {


	public States State;
	protected MoveController Move; 
	public ViewArea View;
	private Transform TargetTransform;
	public AngryablePerson AngryPerson;
	public HitCircle hitCircle;

	public GameObject Origin;


	// hit
	private float HitRange;
	public float Wudi;
	private float Stop=0;

	// rotate
	public int SearchRotate;
	private float TotalRotate;
	public float RotateSpeed = 40f;
	public Facing Face;

	private float RandomRange = 10f;

	// Use this for initialization
	public void Awake () 
	{
		Init ();
	}

	public void Start()
	{
		AdaptFace (View.transform.eulerAngles.z);
		if (GetComponent<PatrolMove> () == null)
			Move.SetTarget (Origin);
	}

	public void Init()
	{
		State = States.Normal;
		SearchRotate = 0;
		Origin = Instantiate (Origin);
		Origin.transform.position = transform.position;

		Move = GetComponent<MoveController> ();
		HitRange = GetComponent<CircleCollider2D> ().radius * 2 + 0.1f;
	}

	public void Update()
	{
//		if (this.gameObject.name == "Character")
//			Debug.Log (View.transform.eulerAngles.z);
//		if (GetComponentInChildren<PoliceView> () == null && State == States.Normal) {
//			GameObject temp = Instantiate (Origin);
//			temp.transform.position += new Vector3((Random.value - 0.5f) * RandomRange, (Random.value - 0.5f) * RandomRange, 0f);
//			Move.SetTarget (temp);
//		}
			

		if (Wudi >= 0.1f)
			Wudi -= Time.deltaTime;
		
//		if (Stop > 0.1f) {
//			Stop -= Time.deltaTime;
//			if (Stop < 0.1f) {
//				Debug.Log ("Stop over");
//			}
//			return;
//		}


		// Search !
		if (SearchRotate != 0) {
			View.transform.Rotate (Vector3.forward * RotateSpeed * Time.deltaTime * SearchRotate);

			AdaptFace (View.transform.eulerAngles.z);

			if (Mathf.Abs (TotalRotate) >= 360)
				SearchRotate = 0;
		} 

		// Hit others
		if (State == States.Angry) 
		{

			float dist = (TargetTransform.position - transform.position).magnitude;
//			Debug.Log (dist);
			if (dist < HitRange)
			{
				State = States.Fight;
				hitCircle.gameObject.SetActive(true);
				AngryPerson.TriggerFight ();
			}
		}

		// Move
		if (Move.target != null) 
		{
			AngryPerson.TriggerRun ();
			Move.UpdateMove();
		}
			
	}

	public void BecomeAngry(GameObject target)
	{
//		Debug.Log ("BecomeAngry");
		AngryPerson.TriggerAngry();
		State = States.Angry;
		SearchRotate = 0;
		Move.SetTarget (target);
		TargetTransform = target.GetComponent<Transform> ();
	}

	public void SetStop(float time)
	{
		Stop = time;
	}

	virtual public void Hit(Vector3 otherVec)
	{
//		Debug.Log ("Hit" + this.gameObject.name);

		if(State == States.Normal && Wudi < 0.1f) // some condition
		{
			AngryPerson.TriggerHit ();
			State = States.WillAngry;
			TotalRotate = 0;

			Vector3 direction = otherVec - transform.position;
			float deg = Mathf.Rad2Deg * Mathf.Atan2 (direction.y, direction.x); 


			float delta = deg - View.transform.eulerAngles.z;
			while (delta > 180)
				delta -= 360;
			while (delta < -180)
				delta += 360;

//			Debug.Log (deg.ToString() + ',' + delta.ToString() );


			if (delta > 0)
				SearchRotate = 1;
			else
				SearchRotate = -1;

		}
	}

	public void Return()
	{
		AngryPerson.TriggerNoAngry();
//		Debug.Log ("Return");
		State = States.Normal;
		hitCircle.gameObject.SetActive(false);
		Move.SetTarget (Origin);
		Wudi = 0.5f;
	}
		

	public void AdaptFace(float deg)
	{
		

		deg -= 90;
		deg = -deg;
		while (deg >= 360)
			deg -= 360;
		while (deg < 0)
			deg += 360;

//		if (gameObject.name == "PoliceCharacter")
//			Debug.Log (deg);

//		if (this.gameObject.name == "Character")
//			Debug.Log (deg);
		
		if (deg <= 315 && deg >= 225) 
		{
			AngryPerson.SetFacing (Facing.left);
			Face = Facing.left;
		} 
		else if(deg <= 135 && deg >= 45)
		{
			AngryPerson.SetFacing (Facing.right);
			Face = Facing.right;
		}
		else if(deg <= 225 && deg >= 135)
		{
			AngryPerson.SetFacing (Facing.down);
			Face = Facing.down;
		}
		else 
		{
			AngryPerson.SetFacing (Facing.up);
			Face = Facing.up;
		}
	}
}
