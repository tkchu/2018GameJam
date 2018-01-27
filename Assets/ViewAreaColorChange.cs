using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewAreaColorChange : MonoBehaviour {
    public Color colorIn;
    public Color colorOut;
    public SpriteRenderer spriteRenderer;

    public void SetPlayerIn(bool isIn) {
        if (isIn) {
            spriteRenderer.color = colorIn;
        }else {
            spriteRenderer.color = colorOut;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            SetPlayerIn(true);
        }
    }
    public void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Player") {
            SetPlayerIn(false);
        }
    }
}
