using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceInactive : MonoBehaviour {

	public CharacterController Cha;
	public ViewArea View;
	void Update () {
		if (Cha.State == States.Angry) {
			View.gameObject.SetActive (false);
		}
	}
}
