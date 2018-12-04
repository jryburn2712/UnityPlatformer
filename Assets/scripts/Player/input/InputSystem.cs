using UnityEngine;

class InputSystem : MonoBehaviour
{
    private Player player;   

    void Awake()
    {
        //Get reference to the character that this script is attached to. (AKA the main character)
        player = GetComponent<Player>();    
    }

    void Update()
    {
        
        //Nothing was pressed
        if (!Input.anyKey)
        {
            player.State.OnNothingPressed(player);
            return;
        }
        if (Input.GetAxis("Horizontal") < 0) //Input.GetKeyDown(KeyCode.A)) // left
        {
            player.State.OnMovePressed(player, Direction.LEFT);
        }
        if (Input.GetAxis("Horizontal") > 0) //Input.GetKeyDown(KeyCode.D)) // right
        {
            player.State.OnMovePressed(player, Direction.RIGHT);
        }
        if (Input.GetKeyDown(KeyCode.Space)) // jump
        {
            player.State.OnJumpPressed(player);
        }

    }

}