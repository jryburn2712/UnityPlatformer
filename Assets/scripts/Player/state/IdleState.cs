using UnityEngine;

class IdleState : State
{

    private const float IDLE_ANIMATION_SPEED = 1.5f;
    public override void OnStateEnter(Player player)
    {
        base.OnStateEnter(player);
        
        //Set the character's x velocity to 0 when entering idle state so the character doesn't keep sliding 
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, player.GetComponent<Rigidbody2D>().velocity.y);

        //Play the idle animation upon entering idle state if it's not already playing
        if (!player.playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("male_idle"))
        {
            player.playerAnimator.speed = IDLE_ANIMATION_SPEED;
            player.playerAnimator.Play("male_idle");
        }
    }

    public override void OnMovePressed(Player player, Direction direction)
    {
        base.OnMovePressed(player, direction);
        
        //Set the new state and pass the button press along to it.
        player.State.SetState(player, player.states[StateType.MOVE]);
        player.State.OnMovePressed(player, direction);        
    }

    public override void OnJumpPressed(Player player)
    {
        base.OnJumpPressed(player);
        //Set the new state and pass the jump press to it.
        player.State.SetState(player, player.states[StateType.JUMP]);
        player.State.OnJumpPressed(player);
    }

    public override void OnAttackPressed(Player player)
    {
        base.OnAttackPressed(player);

        player.State.SetState(player, player.states[StateType.ATTACK]);
        player.State.OnAttackPressed(player);
    }

    public override void Tick(Player player)
    {
        
    }
}