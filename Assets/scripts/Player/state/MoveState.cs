using UnityEngine;

class MoveState : State
{

    public override void OnStateEnter(Player player)
    {
        base.OnStateEnter(player);

        //Check if the character needs to be flipped to face the correct direction.
        if (player.MoveX < 0.0f && !player.FacingRight)
        {
            FlipPlayer(player);
        } else if (player.MoveX > 0.0f && player.FacingRight)
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
        /*
         * Move character in the correct direction by the specified amount (PlayerSpeed). The "MoveX" variable will be either 
         * 1 or -1 depending on which key was pressed (A or D -- this is set from the InputSystem), so multiplying it by the 
         * playerSpeed variable will move your charcter in the correct direction on the x axis. For example, if the user pressed
         * the "A" key, the value stored in "MoveX" will be -1, so multiplying the playerSpeed (10) by -1 will move the character
         * -10 units on the x-axis (aka 10 units to the left). The Y velocity remains the same as it was.
         */
        
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(player.MoveX * player.PlayerSpeed, player.GetComponent<Rigidbody2D>().velocity.y);
        
    }

    //Flips character on the x-axis and sets the facingRight flag.
    private void FlipPlayer(Player player)
    {
        player.FacingRight = !player.FacingRight;
        Vector2 localScale = player.transform.localScale;
        localScale.x *= -1;
        player.gameObject.transform.localScale = localScale;
        
    }
}
