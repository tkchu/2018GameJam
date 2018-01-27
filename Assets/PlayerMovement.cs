using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }
    
    public void SetRunnig(bool running) {
        animator.SetBool("running", running);
    }

    public void SetFacing(Facing facing) {
        switch (facing) {
            case Facing.down:
                animator.SetFloat("MoveRight", 0);
                animator.SetFloat("MoveUp", -1);
                break;
            case Facing.up:
                animator.SetFloat("MoveRight", 0);
                animator.SetFloat("MoveUp", 1);
                break;
            case Facing.left:
                animator.SetFloat("MoveRight", -1);
                animator.SetFloat("MoveUp", 0);
                break;
            case Facing.right:
                animator.SetFloat("MoveRight", 1);
                animator.SetFloat("MoveUp", 0);
                break;
        }
    }
    public void SetFacing(float right, float up) {
        animator.SetFloat("MoveRight", right);
        animator.SetFloat("MoveUp", up);
    }
    public void SetFight(bool isFighting) {
        animator.SetBool("fight", isFighting);
    }
}
