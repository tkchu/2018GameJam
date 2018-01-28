using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCircle : MonoBehaviour {


    public void OnTriggerEnter2D(Collider2D collision) {

		// police can not hit
		if (collision.GetComponentInChildren<PoliceView> () != null// is police
		   && GetComponentInParent<FootballController> () == null)
			return;
        CharacterController c = collision.gameObject.GetComponent<CharacterController>();
        if (c != null) {
            c.Hit(transform.parent.transform.position);
        }


		if (collision.tag == "Player") {
			GameController.GameOver ();
		}

    }
}
