using UnityEngine;

class AttackState : State
{
    public override void OnStateEnter(Player player)
    {
        base.OnStateEnter(player);

        //Start Attack Animation. Check to make sure it's not already playing.
        if (!player.playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("male_attack"))
        {
            player.playerAnimator.Play("male_attack");
            //player.playerAnimator.SetTrigger("male_attack");
        }
    }

    public override void Tick(Player player)
    {
        //Attack(player);
    }

    private void Attack(Player player)
    {
        
    }
}