using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snailFoundBehaviour : StateMachineBehaviour
{

    public GameObject mainCam, bossCam, b1, b2, b3;
    private Transform searchArea;
    public float searchRad;
    public LayerMask whatIsPlayer;
    private Collider2D target;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (mainCam == null) mainCam = animator.gameObject.GetComponent<snailReferences>().mainCam;
        if (bossCam == null) bossCam = animator.gameObject.GetComponent<snailReferences>().bossCam;
        if (searchArea == null) searchArea = animator.gameObject.GetComponent<snailReferences>().searchpos;
        if (b1 == null) b1 = animator.gameObject.GetComponent<snailReferences>().b1;
        if (b2 == null) b2 = animator.gameObject.GetComponent<snailReferences>().b2;
        if (b3 == null) b3 = animator.gameObject.GetComponent<snailReferences>().b3;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = Physics2D.OverlapCircle(searchArea.position, searchRad, whatIsPlayer);
        if (target != null) animator.SetTrigger("PlayerFound");
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        b1.gameObject.SetActive(true);
        b2.gameObject.SetActive(true);
        b3.gameObject.SetActive(true);
        mainCam.gameObject.SetActive(false);
        bossCam.gameObject.SetActive(true);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(searchArea.position, searchRad);
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
