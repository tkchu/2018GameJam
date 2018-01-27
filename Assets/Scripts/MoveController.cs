using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour {

	public GameObject target;

	private Rigidbody2D rgb;
	private float MoveSpeed = 1f;

	public bool AtTarget;

	void Start () {
		rgb = GetComponent<Rigidbody2D> ();
	}

	void LateUpdate () {

//		if (target == null || AtTarget)
//			return;

		if (target == null)
			return;
		
		Vector3 direction = target.transform.position - transform.position;
		float dist = direction.magnitude;

		direction.Normalize ();
//		rgb.velocity = direction * MoveSpeed;
		rgb.AddForce(direction * MoveSpeed);
		if (rgb.velocity.magnitude >= MoveSpeed)
			rgb.velocity = rgb.velocity.normalized * MoveSpeed;

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
}
