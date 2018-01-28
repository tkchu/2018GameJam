using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour {
    Animator animator;
    Animator parentAnimator;
    SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        parentAnimator = transform.parent.GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Update() {
        AnimatorStateInfo info = parentAnimator.GetCurrentAnimatorStateInfo(0);
        bool isFighting = info.IsName("football-front-fight")
            || info.IsName("football-back-fight")
            || info.IsName("football-side-fight");
        int facing = parentAnimator.GetInteger("facing");
        spriteRenderer.flipX = facing == 3;
        spriteRenderer.flipY = facing == 0;
        animator.SetInteger("facing", facing);
        animator.SetBool("fight", isFighting);
    }
}
