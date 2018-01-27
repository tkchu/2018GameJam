using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {


	public States State;
	private MoveController Move; 
	private ViewArea View;
	private CharacterController TargetCtrl;

	private float HitRange;

	// rotate
	public int SearchRotate;
	private float RotateSpeed = 40f;

	// Use this for initialization
	void Awake () 
	{
		Init ();


//		test();
	}

	void test()
	{
		State = States.WillAngry;
		SearchRotate = 1;
	}

	void Init()
	{
		State = States.Normal;
		SearchRotate = 0;
		Move = GetComponent<MoveController> ();
		HitRange = GetComponent<CircleCollider2D> ().radius * 2 + 0.1f;
		View = GetComponentInChildren<ViewArea> ();
	}

	void Update()
	{
		// Search !
		if (SearchRotate != 0) 
		{
			View.transform.Rotate (Vector3.forward * RotateSpeed * Time.deltaTime * SearchRotate);
		}

		// Hit others
		if (TargetCtrl != null) 
		{
			float dist = (TargetCtrl.transform.position - transform.position).magnitude;
//			Debug.Log (dist);
			if (dist < HitRange)
				TargetCtrl.Hit (this);
		}
	}

	public void BecomeAngry(GameObject target)
	{
//		Debug.Log ("BecomeAngry");
		State = States.Angry;
		SearchRotate = 0;
		Move.SetTarget (target);
		TargetCtrl = target.GetComponent<CharacterController> ();
	}

	public void Hit(CharacterController other)
	{
//		Debug.Log ("Hit" + this.gameObject.name);

		if(State == States.Normal) // some condition
		{
			State = States.WillAngry;


			Vector3 direction = other.transform.position - transform.position;
			float deg = Mathf.Rad2Deg * Mathf.Atan2 (direction.y, direction.x); 
			float delta = deg - transform.rotation.z;
			while (delta > 180)
				delta -= 360;
			while (delta < -180)
				delta += 360;
			
			if (delta > 0)
				SearchRotate = 1;
			else
				SearchRotate = -1;

		}
	}
}
