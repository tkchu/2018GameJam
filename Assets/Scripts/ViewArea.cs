using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewArea : MonoBehaviour {

	// Use this for initialization
	protected CharacterController character;

	void Start()
	{
		character = GetComponentInParent<CharacterController> ();
	}

	void Update()
	{

	}

	virtual public void OnTriggerStay2D(Collider2D other)
	{
		if (character.State != States.WillAngry || (other.tag != "Character" && other.tag != "Player"))
			return;

		Vector3 direction = (other.transform.position - transform.position).normalized;

		Collider2D hit = Physics2D.Raycast (transform.position + direction * (GetComponentInParent<CircleCollider2D>().radius*2), 
			other.transform.position,  
			Mathf.Infinity, LayerMask.GetMask ("Collider")).collider;


		if (hit == null || hit == other) 
		{
//			Debug.Log ("View2");
			character.BecomeAngry (other.gameObject);
		}
		

	}
}
