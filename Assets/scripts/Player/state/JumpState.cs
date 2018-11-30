using UnityEngine;

class JumpState : State
{
	public override void OnStateEnter(Player player)
	{
        // base.OnStateEnter(player);

        // if (player.GetComponent<Rigidbody2D>().velocity.magnitude == 0);
        // {
        //     player.isGrounded = true;
        // }
	}

	public override void Tick(Player player)
    {
        Jump(player);
    }

    private void Jump(Player player)
    {
       player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * player.jumpForce);
    }
}