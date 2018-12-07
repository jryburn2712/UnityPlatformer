
using UnityEngine;
using UnityEngine.SceneManagement;

class PauseGameState : GameState
{
    private Player player;
    private GameObject pauseMenu;
    public override void OnGameStateEnter(GameState previousGameState)
    {
        base.OnGameStateEnter(previousGameState);
        player = GameManager.Instance.player;
        ActivatePauseMenu();
        disablePlayerInputSystem();
        freezePlayer();
        pauseAudio();
    }

    public override void OnGameStateExit()
    {
        base.OnGameStateExit();
        unfreezePlayer();
        DeactivatePauseMenu();
        enablePlayerInputSystem();
        unPauseAudio();
    }


    private void ActivatePauseMenu()
    {
        //Get current scene, find pause menu, activate it
        Scene scene = SceneManager.GetActiveScene();
        foreach (GameObject obj in scene.GetRootGameObjects())
        {
            if (obj.name.Equals("PauseMenu"))
            {
                pauseMenu = obj;
            }
        }

        pauseMenu.SetActive(true);
    }

    private void DeactivatePauseMenu()
    {
        pauseMenu.SetActive(false);
    }

    private void freezePlayer()
    {
        player.State.SetState(player, player.states[StateType.IDLE]);
        player.CachedRigidBody.isKinematic = true;
        player.CachedRigidBody.velocity = Vector2.zero;
        player.playerAnimator.enabled = false;
    }

    private void unfreezePlayer()
    {
        player.CachedRigidBody.isKinematic = false;
        player.playerAnimator.enabled = true;
    }

    private void pauseAudio()
    {
        Camera.main.GetComponent<AudioSource>().Pause();
    }

    private void unPauseAudio()
    {
        Camera.main.GetComponent<AudioSource>().UnPause();
    }

    private void disablePlayerInputSystem()
    {
        player.GetComponent<InputSystem>().paused = true;
    }

    private void enablePlayerInputSystem()
    {
        player.GetComponent<InputSystem>().paused = false;
    }

}

