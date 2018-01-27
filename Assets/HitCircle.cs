using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCircle : MonoBehaviour {
    public void OnTriggerEnter2D(Collider2D collision) {
        CharacterController c = collision.gameObject.GetComponent<CharacterController>();
        if (c != null) {
            c.Hit(transform.parent.transform.position);
        }
    }
}
