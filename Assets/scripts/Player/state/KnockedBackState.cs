
using System.Collections;
using UnityEngine;

class KnockedBackState : State
{
    private Color invisible, visible;

    public override void OnStateEnter(Player player)
    {
        base.OnStateEnter(player);
        player.playerAnimator.StopPlayback();

        //Get original color of sprite
        visible = player.cachedSpriteRenderer.color;

        //Use same sprite color as original but set the alpha to zero to make invisible
        invisible = visible;
        invisible.a = 0f;

        performKnockback(player);
        player.StartCoroutine(Flash(player));
    }

    public override void Tick(Player player)
    {
        
    }

    private void performKnockback(Player player)
    {
        float xVel = player.CachedRigidBody.velocity.x;

        
        if (xVel > 0) //PLayer was moving right, knock back to the left
        {
            player.CachedRigidBody.AddForce(new Vector2(-1, 1) * player.knockBackForce * Time.deltaTime, ForceMode2D.Impulse);
        } else // Player was moving left, knock back to the right
        {
            player.CachedRigidBody.AddForce(new Vector2(1, 1) * player.knockBackForce * Time.deltaTime, ForceMode2D.Impulse);
        }
    }

    //Makes player flash when hit.
    private IEnumerator Flash(Player player)
    {
        for (int i = 0; i < 3; i++) 
        {
            player.cachedSpriteRenderer.material.color = invisible;
            yield return new WaitForSeconds(.1f);
            player.cachedSpriteRenderer.material.color = visible;
            yield return new WaitForSeconds(.1f);
        }
        player.State.SetState(player, player.states[StateType.IDLE]);
    }
}

