public class GameOverState : GameState
{
    public override void OnGameStateEnter(GameState previousGameState)
    {
        base.OnGameStateEnter(previousGameState);        

        gameManager.LoadScene(gameManager.GetCurrentSceneName());
    }
}