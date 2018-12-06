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
        if (Input.GetButtonDown("Jump")) // jump
        {
            player.State.OnJumpPressed(player);
        }
        if (Input.GetButtonDown("Fire1")) // attack
        {
            player.State.OnAttackPressed(player);
        }

        
        //Using only for testing player's DeathState. Each time the right mouse button is clicked, the player loses 100 health. 
        if (Input.GetButtonDown("Fire2"))
        {
            player.playerHealth -= 100;
        }
    }
}