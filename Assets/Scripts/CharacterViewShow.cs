using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterViewShow : MonoBehaviour {

	public CharacterController Cha;
	public SpriteRenderer SR;

	void Update () {
		SR.enabled = (Cha.SearchRotate != 0);
	}
}
