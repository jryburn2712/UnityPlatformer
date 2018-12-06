public abstract class GameState : IGameState, ISceneHandler
{
    public virtual void OnNewGame(GameScene gameScene)
    {

    }

    public virtual void OnPlayGame(GameScene gameScene)
    {

    }

    public virtual void OnGameOver(GameScene gameScene)
    {

    }

    public virtual void OnGameStateEnter(GameScene gameScene)
    {

    }

    public virtual void OnGameStateExit(GameScene gameScene)
    {

    }

    public virtual void SetGameState(GameScene gameScene, GameState gameState)
    {
        gameScene.GameState.OnGameStateExit(gameScene);
        gameScene.GameState = gameState;
        gameScene.GameState.OnGameStateEnter(gameScene);
    }

    public virtual void Tick(GameScene gameScene)
    {

    }
}