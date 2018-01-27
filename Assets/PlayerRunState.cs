using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : StateMachineBehaviour {

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
    public AnimationClip leftRun;
    public AnimationClip rightRun;
    public AnimationClip upRun;
    public AnimationClip downRun;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) {
        Facing facing = (Facing)animator.GetInteger("facing");
        switch (facing) {
            case Facing.down:
                animator.Play(downRun.name);
                break;
            case Facing.up:
                animator.Play(downRun.name);
                break;
            case Facing.right:
                animator.Play(downRun.name);
                break;
            case Facing.left:
                animator.Play(leftRun.name);
                break;

        }
    }
}
