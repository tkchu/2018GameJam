using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryableFace : MonoBehaviour {
    public Sprite down;
    public Sprite up;
    public Sprite side;
    SpriteRenderer spriteRenderer;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetFacing(Facing facing) {
        switch (facing) {
            case Facing.down:
                spriteRenderer.sprite = down;
                break;
            case Facing.up:
                spriteRenderer.sprite = up;
                break;
            case Facing.left:
                spriteRenderer.sprite = side;
                spriteRenderer.flipX = true;
                break;
            case Facing.right:
                spriteRenderer.sprite = side;
                spriteRenderer.flipX = false;
                break;
        }
    }
}
