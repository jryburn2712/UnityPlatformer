using UnityEngine;

class InputSystem : MonoBehaviour
{
    private Player player;
    private Command move, jump, idle;

    void Awake()
    {
        //Get reference to the character that this script is attached to. (AKA the main character)
        player = GetComponent<Player>();

        move = new MoveCommand();
        jump = new JumpCommand();
        idle = new IdleCommand();
    }

    void Update()
    {
        /*
         * Use the axis to determine if a button was pressed. This avoids hardcoding specific keys into the code.
         * The GetAxis() methods return a value between -1 and 1. If the negative button was pressed, the value will be 
         * below 0. If the positive button was pressed, the value will be above 0. If nothing was pressed, the value will
         * be 0. These values will be multiplied by the player speed to determine the how far the character should move, as
         * well as which direction he should be facing. To see which keys are currently bound to the negative and positive
         * buttons (i.e A, D, left, right, etc...), in Unity use Edit ---> Project Settings ---> Input
         * 
         */
        player.SetMovement(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        player.SetJump(Input.GetButtonDown("Jump"));
    }

    void FixedUpdate()
    {
        if (!ShouldMove())
        {                       
            //The character was not moving, so execute idle command. See classes IdleCommand and IdleState.
            idle.Execute(player);
        }
        if (ShouldMove())
        {         
            //Character was moving, execute the move command. See classes MoveCommand and MoveState.
            move.Execute(player);
        }
        if (ShouldJump())
        {
            //Check if the character isnt already jumping by reaading the velocity of the Y axis
            jump.Execute(player);
        }
    }

    //Determines if the character should be switched to the MoveState based on the X value of the characters's 
    //Movement Vector2. If the x value is not 0, then the character is moving.
    private bool ShouldMove()
    {
        return player.Movement.x != 0;
    }

    private bool ShouldJump()
    {
        //return player.Jumping && player.isGrounded;
        return player.Jumping && player.GetComponent<Rigidbody2D>().velocity.magnitude == 0;
    }
}