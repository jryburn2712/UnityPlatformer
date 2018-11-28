
class IdleState : State
{

    public override void OnStateEnter(Player player)
    {
        base.OnStateEnter(player);
        
        //Play the idle animation upon entering idle state if it's not already playing
        if (!player.playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("male_idle"))
        {
            player.playerAnimator.Play("male_idle");
        }
    }

    public override void Tick(Player player)
    {
            
    }
}

