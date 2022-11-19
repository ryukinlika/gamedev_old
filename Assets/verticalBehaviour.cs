using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class verticalBehaviour : StateMachineBehaviour
{

    private GameObject player, proj;
    bool shot;
    private float timer;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player == null) player = animator.gameObject.GetComponent<snailReferences>().player;
        if (proj == null) proj = animator.gameObject.GetComponent<snailReferences>().projectileV;
        timer = 3f;
        shot = false;
        Instantiate(proj, new Vector3(player.transform.position.x, player.transform.position.y + 10, player.transform.position.z), proj.transform.rotation);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
        {
            animator.SetBool("Vertical", false);
        }
        else
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 2 && !shot)
        {
            Instantiate(proj, new Vector3(player.transform.position.x, player.transform.position.y + 10, player.transform.position.z), proj.transform.rotation);
            shot = true;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Vertical", false);
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
