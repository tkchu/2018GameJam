using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceView : ViewArea {

	override public void OnTriggerStay2D (Collider2D other)
	{
		if (character.State == States.WillAngry && other.tag == "Player")
			GameController.GameOver ();

		if (other.tag == "Player" && other.GetComponent<PlayerControl>().isFighting)
			GameController.GameOver ();

		if (other.tag == "Character" && 
			(other.GetComponent<CharacterController> ().State == States.Fight || other.GetComponent<CharacterController> ().State == States.Angry)
			&& character.State == States.Normal && other.GetComponentInChildren<PoliceView> == null) 
		{
			character.SetStop (2);
			character.AngryPerson.TriggerWhistle ();
//			Debug.Log ("Stop!!!");

			other.GetComponent<CharacterController>().Return ();
		}

		base.OnTriggerStay2D (other);
	}
}
