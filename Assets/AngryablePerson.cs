using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AngryablePerson : MonoBehaviour {
    Animator animator;
    SpriteRenderer spriteRenderer;
    public AngryableFace angryableFace;

    private void Awake() {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public GameObject hitIcon;
    public void TriggerHit() {
        StartCoroutine(ShowHit());
    }
    IEnumerator ShowHit() {
        hitIcon.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        hitIcon.SetActive(false);
    }
    public void TriggerNoAngry() {
        animator.SetTrigger("noAngryTrigger");
        angryableFace.SetAngry(false);
    }
    public void TriggerAngry() {
        angryableFace.SetAngry(true);
        if (gameObject.name == "normalPerson"
            &&
            (animator.GetCurrentAnimatorStateInfo(0).IsName("normal-front-fight")
            || animator.GetCurrentAnimatorStateInfo(0).IsName("normal-back-fight")
            || animator.GetCurrentAnimatorStateInfo(0).IsName("normal-side-fight")
            )) {
            angryableFace.SetAngry(false);
        }
    }
    public void TriggerRun() {
        animator.SetTrigger("runTrigger");
        animator.SetBool("isRunning", true);
    }
    public void TriggerFight() {
        animator.SetTrigger("fightTrigger");
        if(gameObject.name == "normalPerson") {
            angryableFace.SetAngry(false);
        }
    }
    public void TriggerWhistle() {
        animator.SetTrigger("whistleTrigger");
        StartCoroutine(HideFaceWhileWhistle());
    }
    IEnumerator HideFaceWhileWhistle() {
        bool angry = angryableFace.angry;
        angryableFace.SetAngry(false);
        yield return new WaitForEndOfFrame();
        yield return new WaitWhile(() => animator.GetCurrentAnimatorStateInfo(0).IsName("whistle"));
        angryableFace.SetAngry(angry);
    }
    public void SetFacing(Facing facing) {
        switch (facing) {
            case Facing.down:
                animator.SetInteger("facing", 0);
                animator.SetFloat("MoveRight", 0);
                animator.SetFloat("MoveUp", -1);
                break;
            case Facing.up:
                animator.SetInteger("facing", 1);
                animator.SetFloat("MoveRight", 0);
                animator.SetFloat("MoveUp", 1);
                break;
            case Facing.left:
                animator.SetInteger("facing", 2);
                animator.SetFloat("MoveRight", 1);
                animator.SetFloat("MoveUp", 0);
                spriteRenderer.flipX = true;
                break;
            case Facing.right:
                animator.SetInteger("facing", 2);
                animator.SetFloat("MoveRight", 1);
                animator.SetFloat("MoveUp", 0);
                spriteRenderer.flipX = false;
                break;
        }
        angryableFace.SetFacing(facing);
    }
}
