


using UnityEngine;

class InputSystem : MonoBehaviour
{

    private Player player;
    private Command move, idle;

    void Awake()
    {
        //Get reference to the character that this script is attached to. (AKA the main character)
        player = GetComponent<Player>();

        move = new MoveCommand();
        idle = new IdleCommand();
    }

    void Update()
    {
        /*Determine if the charcter is moving horizontally (A, D, LEFT, or RIGHT were pressed).
         * This method will return a number between -1 and 1, depending on which button was pressed.
         * A or LEFT = -1, D or RIGHT = 1, Nothing = 0.
         */
        player.MoveX = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        if (player.MoveX != 0)
        {
            //Setting this is not necessary right now, but may be useful in the future.
            player.IsMoving = true;

            //Character was moving, execute the move command. See classes MoveCommand and MoveState.
            move.Execute(player);
        } else
        {

            player.IsMoving = false;
            
            //The character was not moving, so execute idle command. See classes IdleCommand and IdleState.
            idle.Execute(player);
        }
    }

}

