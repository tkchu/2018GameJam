using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceView : ViewArea {

	public GameController Game;

	public void OnTriggerStay2D (Collider2D other)
	{
		if (character.State == States.WillAngry && other.tag == "Player")
			Game.GameOver ();
		
		base.OnTriggerStay2D (other);
	}
}
