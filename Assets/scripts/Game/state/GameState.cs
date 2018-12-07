public abstract class GameState : IGameState
{

    protected GameManager gameManager;

    public GameState()
    {
        gameManager = GameManager.Instance;
    }

    public virtual void OnGameStateEnter(GameState previousGameState)
    {

    }

    public virtual void OnGameStateExit()
    {

    }

    public virtual void SetGameState(GameState gameState)
    {
        GameState previousGameState = gameManager.GameState;
        gameManager.GameState.OnGameStateExit();
        gameManager.GameState = gameState;
        gameManager.GameState.OnGameStateEnter(previousGameState);
    }
    
}