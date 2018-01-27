using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceView : ViewArea {

	public GameController Game;

	override public void OnTriggerStay2D (Collider2D other)
	{
		if (character.State == States.WillAngry && other.tag == "Player")
			Game.GameOver ();

		if (other.tag == "Player" && other.GetComponent<PlayerControl>().isFighting)
			Game.GameOver ();

		if (other.tag == "Character" && other.GetComponent<CharacterController> ().State == States.Fight &&
			character.State == States.Normal) 
		{
			character.SetStop (2);
			Debug.Log ("Stop!!!");
		}

		base.OnTriggerStay2D (other);
	}
}
