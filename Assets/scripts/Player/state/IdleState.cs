using UnityEngine;

class IdleState : State
{    
    public override void OnStateEnter(Player player)
    {
        base.OnStateEnter(player);
        
        //Set the character's x velocity to 0 when entering idle state so the character doesn't keep sliding 
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, player.GetComponent<Rigidbody2D>().velocity.y);

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