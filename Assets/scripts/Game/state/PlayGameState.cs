
public class PlayGameState : GameState
{
    private const string sceneToLoad = "Bonus1";

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
            GameManager.Instance.LoadScene(sceneToLoad);
        }
        
    }

    public override void OnGameStateExit()
    {
        base.OnGameStateExit();
    }
}