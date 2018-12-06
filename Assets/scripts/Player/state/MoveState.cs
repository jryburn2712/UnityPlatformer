using UnityEngine;

class MoveState : State
{
    private bool movingLeft;
    private bool movingRight;
    private Direction direction;
    private const float PLAYER_SPEED_TO_ANIMATION_SPEED_RATIO = 150.0f;

    public override void OnStateEnter(Player player)
    {
        base.OnStateEnter(player);

        if (!player.playerAnimator.GetCurrentAnimatorStateInfo(0).IsName(player.getWalkAnimName()))
        {
            player.playerAnimator.speed = player.PlayerSpeed / PLAYER_SPEED_TO_ANIMATION_SPEED_RATIO;
            player.playerAnimator.Play(player.getWalkAnimName());
        }

        //OnMovePressed(player, direction);
    }

    public override void Tick(Player player)
    {        
        Move(player);    
    }

    public override void OnMovePressed(Player player, Direction direction)
    {
        base.OnMovePressed(player, direction);

        switch (direction)
        {
            case Direction.LEFT:              
                movingLeft = true;
                movingRight = false;               
                break;
            case Direction.RIGHT:               
                movingRight = true;
                movingLeft = false;                
                break;
        }

        this.direction = direction;
    }

    public override void OnMoveReleased(Player player, Direction direction)
    {
        base.OnMoveReleased(player, direction);
    }

    public override void OnJumpPressed(Player player)
    {
        base.OnJumpPressed(player);
        player.State.SetState(player, player.states[StateType.JUMP]);
        player.State.OnJumpPressed(player);
    }

    public override void OnAttackPressed(Player player)
    {
        base.OnAttackPressed(player);
        player.State.SetState(player, player.states[StateType.ATTACK]);
        player.State.OnAttackPressed(player);
    }

    public override void OnNothingPressed(Player player)
    {
        base.OnNothingPressed(player);
        player.State.SetState(player, player.states[StateType.IDLE]);
    }

    /*
     * Each of the values in the Player's Movement Vector2 will be multiplied by the Player's movement speed.
     * The x and y values in the Vector2 will always be between -1 and 1, depending on which button was pressed
     * by the user, so the character will always move in the correct direction (Left if total value is negative, right
     * if total value is positive). This value is multiplied by the delta time to keep the framerate smooth.
     */
    private void Move(Player player)
    {              
        if (movingLeft)
        {
            if (!player.isFacingLeft)
            {
                FlipPlayer(player);
            }
            player.CachedRigidBody.velocity = new Vector2(-1 * player.PlayerSpeed * Time.deltaTime, player.GetComponent<Rigidbody2D>().velocity.y);        
        }
        else if (movingRight)
        {
            if (player.isFacingLeft)
            {
                FlipPlayer(player);
            }
            player.CachedRigidBody.velocity = new Vector2(player.PlayerSpeed * Time.deltaTime, player.GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    //Flips character on the x-axis and sets the facingLeft flag.
    private void FlipPlayer(Player player)
    {
        player.isFacingLeft = !player.isFacingLeft;
        Vector2 localScale = player.transform.localScale;
        localScale.x *= -1;
        player.gameObject.transform.localScale = localScale;        
    }
}