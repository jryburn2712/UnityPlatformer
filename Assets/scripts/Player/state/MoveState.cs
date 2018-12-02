using UnityEngine;

class MoveState : State
{
    public override void OnStateEnter(Player player)
    {
        base.OnStateEnter(player);

        //Check if the character needs to be flipped to face the correct direction.
        if (player.Movement.x < 0.0f && !player.isFacingLeft)
        {
            FlipPlayer(player);
        }
        else if (player.Movement.x > 0.0f && player.isFacingLeft)
        {
            FlipPlayer(player);
        }

        //Start Walk Animation. Check to make sure it's not already playing.
        if (!player.playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("male_walk"))
        {
            player.playerAnimator.Play("male_walk");
        }
    }

    public override void Tick(Player player)
    {      
        Move(player);
    }

    /*
     * Each of the values in the Player's Movement Vector2 will be multiplied by the Player's movement speed.
     * The x and y values in the Vector2 will always be between -1 and 1, depending on which button was pressed
     * by the user, so the character will always move in the correct direction (Left if total value is negative, right
     * if total value is positive). This value is multiplied by the delta time to keep the framerate smooth.
     */
    private void Move(Player player)
    {
        player.CachedRigidBody.velocity = new Vector2(player.Movement.x * player.PlayerSpeed, player.CachedRigidBody.velocity.y);
    }

    //Flips character on the x-axis and sets the facingRight flag.
    private void FlipPlayer(Player player)
    {
        player.isFacingLeft = !player.isFacingLeft;
        Vector2 localScale = player.transform.localScale;
        localScale.x *= -1;
        player.gameObject.transform.localScale = localScale;        
    }
}