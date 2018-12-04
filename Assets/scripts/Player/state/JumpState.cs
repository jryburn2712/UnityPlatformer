using UnityEngine;

class JumpState : State
{
    private bool shouldJump;
    private bool beforeJump;

	public override void OnStateEnter(Player player)
	{
        beforeJump = true;

        //Start Jump Animation. Check to make sure it's not already playing.
        if (!player.playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("male_jump"))
        {
            player.playerAnimator.Play("male_jump");
        }
    }

    public override void OnMovePressed(Player player, Direction direction)
    {
        base.OnMovePressed(player, direction);
        // TODO: Find a better way to handle movement in the air. Switching to moveState while jumping
        // defeats the purpose of having a jumpState in the first place.
        player.State.SetState(player, player.states[StateType.MOVE]);
        player.State.OnMovePressed(player, direction);
        
    }

    public override void OnAttackPressed(Player player)
    {
        base.OnAttackPressed(player);
        player.State.SetState(player, player.states[StateType.ATTACK]);
    }

    public override void Tick(Player player)
    {       
        Jump(player);
    }

    private void Jump(Player player)
    {
        if (isGrounded(player))
        {
            /*The player can be grounded either before or after the jump. When jumpState state is entered,
            / the beforeJump flag is set to true, so we know that the jump hasn't occured yet. If beforeJump is false,
            / then we know that the jump already happened and the player is back on the ground, so the
            / jumpState should be exited. 
            /
            / TODO: Find a better way to handle what happens when the jump is finished, aka when beforeJump is false.
            / Right now, the state is simply set to Idle.
            */
            if (beforeJump)
            {
                player.CachedRigidBody.AddForce(new Vector2(0, player.jumpForce), ForceMode2D.Impulse);
                beforeJump = false;
            }
            else
            {
                player.State.SetState(player, player.states[StateType.IDLE]);
            }
            
        }
    }

    private bool isGrounded(Player player)
    {
        return player.CachedRigidBody.velocity.y == 0;
        
    }
}