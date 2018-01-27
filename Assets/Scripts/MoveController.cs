using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour {

	public GameObject target;
	private CharacterController ParentCtrl;
	private ViewArea View;
	[HideInInspector]
	public Rigidbody2D rgb;

	public float MoveSpeed = 2f;

	public bool AtTarget;

	public void Start () {
		rgb = GetComponent<Rigidbody2D> ();
		ParentCtrl = GetComponent<CharacterController> ();
		View = ParentCtrl.View;
	}

	virtual public void UpdateMove () {

		if (target == null)
			return;
//		Debug.Log (target.transform.position);
		Vector3 direction = target.transform.position - transform.position;
		float dist = direction.magnitude;

		direction.Normalize ();
//		rgb.velocity = direction * MoveSpeed;
		rgb.AddForce(direction * MoveSpeed);
		if (rgb.velocity.magnitude >= MoveSpeed)
			rgb.velocity = rgb.velocity.normalized * MoveSpeed;

		float deg = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
		float delta = deg - (View.transform.eulerAngles.z);

		while (delta > 180f)
			delta -= 360f;
		while (delta < -180f)
			delta += 360f;


//		if (this.gameObject.name == "Character")
//			Debug.Log (deg.ToString() + "," + (View.transform.eulerAngles.z).ToString() + "," + delta.ToString() );
		
		if (Mathf.Abs (delta) > 10f) 
		{
			delta /= Mathf.Abs(delta);

			View.transform.Rotate (Vector3.forward * ParentCtrl.RotateSpeed * Time.deltaTime * delta);

			ParentCtrl.AdaptFace (deg);
		}

	}

	public void SetTarget(GameObject target)
	{
		this.target = target;
		AtTarget = false;
	}

	void OnTriggerEnter2D(Collider2D other) {
		AtTarget = true;
		// rgb.velocity = Vector3.zero;
	}

	void OnTriggerExit(Collider other)
	{
		AtTarget = false;
	}

	public float GetDist()
	{
		return (transform.position - target.transform.position).magnitude;
	}
}
