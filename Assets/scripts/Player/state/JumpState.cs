using UnityEngine;

class JumpState : State
{
	public override void OnStateEnter(Player player)
	{

	}

	public override void Tick(Player player)
    {      
        Jump(player);
    }

    private void Jump(Player player)
    {
        if(player.GetComponent<Rigidbody2D>().velocity.magnitude == 0)
        {
            player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * player.jumpForce);
        }
        //player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * player.jumpForce);
    }
}