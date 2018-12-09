
public class PlayGameState : GameState
{
    
    public override void OnGameStateEnter(GameState previousGameState)
    {
        base.OnGameStateEnter(previousGameState);
        //If previous gameState was PausedState, resume Scene.
        if (previousGameState is PauseGameState)
        {
            //Resume Scene
        } else
        {
            //Load new scene
            GameManager.Instance.LoadNextScene();
        }
        
    }

    public override void OnGameStateExit()
    {
        base.OnGameStateExit();
    }
}