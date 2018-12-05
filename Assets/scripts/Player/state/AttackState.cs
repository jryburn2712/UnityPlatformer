using UnityEngine;

class AttackState : State
{

    private const float ATTACK_SPEED = 2.0f;

    public override void OnStateEnter(Player player)
    {
        base.OnStateEnter(player);

        //Start Attack Animation. Check to make sure it's not already playing.
        if (!player.playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("male_attack"))
        {
            player.playerAnimator.speed = ATTACK_SPEED;
            player.playerAnimator.Play("male_attack");
        }

    }
    public override void Tick(Player player)
    {
        Attack(player);
    }

    private void Attack(Player player)
    {
        if (!isAnimationPlaying(player))
        {
            player.State.SetState(player, player.states[StateType.IDLE]);
        }
    }

    private bool isAnimationPlaying(Player player)
    {
        return player.playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1;
    }
}