using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snailIdle : StateMachineBehaviour
{

    public float flatTime;
    private float timer;
    private int maxHp, Hp, rand;
    private Transform pit;
    public LayerMask whatIsPlayer;
    public Collider2D target;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        maxHp = animator.GetComponent<snailH>().maxHp;
        Hp = animator.GetComponent<snailH>().health;
        timer = flatTime + 2 * (Hp / maxHp);
        pit = animator.GetComponent<snailReferences>().pit;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
        {
            target = Physics2D.OverlapBox(pit.position, new Vector2(10f, 4f), 0, whatIsPlayer);
            rand = Random.Range(0, 2);
            if (rand == 0 || target != null)
            {
                animator.SetBool("Vertical", true);
            }
            else
            {
                animator.SetBool("Horizontal", true);
            }
        }
        else timer -= Time.deltaTime;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

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
