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
        player.CachedRigidBody.AddForce(Vector2.up * player.jumpForce);
    }
}