using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dedsnail : StateMachineBehaviour
{

    private GameObject ded, final;
    private SpriteRenderer sr;
    public float timer = 3f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        sr = animator.gameObject.GetComponent<snailReferences>().sr;
        ded = animator.gameObject.GetComponent<snailReferences>().ded;
        final = animator.gameObject.GetComponent<snailReferences>().final;
        animator.gameObject.tag = "Untagged";
        animator.gameObject.GetComponent<snailH>().enabled = false;
    }


    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 3 && timer > 0)
        {
            timer -= Time.deltaTime;
            Instantiate(ded, animator.transform.position, Random.rotation);
        }
        else if (timer <= 0)
        {
            Instantiate(final, animator.transform.position, Quaternion.identity);
            animator.SetBool("body", true);
        }
        else timer -= Time.deltaTime;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        sr.color = new Color(0.3f, 0.3f, 0.3f);
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
