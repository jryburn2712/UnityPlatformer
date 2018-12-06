
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

class DeathState : State
{
    public DeathType DeathType { get; set; }

    private bool shouldRestart;

    public override void OnStateEnter(Player player)
    {
        base.OnStateEnter(player);
        if (DeathType == DeathType.ENEMY)
        {

            //Stop the character from moving while Death Animation is Playing
            player.CachedRigidBody.velocity = Vector2.zero;
            //Play the death animation only if the player was killed by an enemy (didn't fall off map)
            player.playerAnimator.Play(player.getDeathAnimName());

            //Wait for a few seconds and then restart the level. 
            //TODO: Add a death screen that allows to restart or go back to menu instead of restarting automatically.
            player.StartCoroutine(waitAfterDeath());
        } else
        {
            //If the player fell off the map, there is no need to play the death animation. Just restart the level.
            //TODO: Again, add death screen as opposed to just restarting the level.
            RestartCurrentLevel();
        }
    }

    public override void Tick(Player player)
    {
        
    }

    public void SetDeathType(DeathType deathType)
    {
        this.DeathType = deathType;
    }

    private void RestartCurrentLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    private IEnumerator waitAfterDeath()
    {
        yield return new WaitForSeconds(3);
        RestartCurrentLevel();
    }
}