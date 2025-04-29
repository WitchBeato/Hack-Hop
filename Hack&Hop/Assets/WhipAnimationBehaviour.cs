using UnityEngine;

public class WhipAnimationBehaviour : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        BossAttackManager.instance.AttackWhipContiune();
    }
}