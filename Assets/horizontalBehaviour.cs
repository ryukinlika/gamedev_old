using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horizontalBehaviour : StateMachineBehaviour
{
    private Transform p1, p2;
    private GameObject proj;
    private int rad;
    private float t1, t2, timer;
    private bool b1, b2;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        b1 = false;
        b2 = false;
        t1 = 0.2f;
        t2 = 0.2f;
        timer = 3.5f;
        p1 = animator.gameObject.GetComponent<snailReferences>().aPos1;
        p2 = animator.gameObject.GetComponent<snailReferences>().aPos2;
        proj = animator.gameObject.GetComponent<snailReferences>().projectileH;
        rad = Random.Range(0, 2);
        if (rad == 0)
        {
            t1 += 1f;
        }
        else t2 += 1f;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
        {
            animator.SetBool("Horizontal", false);
        }
        else
        {
            timer -= Time.deltaTime;
        }
        if (t1 <= 0 && !b1)
        {
            Instantiate(proj, p1.position, Quaternion.identity);
            b1 = true;
        }
        else
        {
            t1 -= Time.deltaTime;
        }
        if (t2 <= 0 && !b2)
        {
            Instantiate(proj, p2.position, Quaternion.identity);
            b2 = true;
        }
        else
        {
            t2 -= Time.deltaTime;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Horizontal", false);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
