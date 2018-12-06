public interface IGameState
{
    void OnGameStateEnter(GameScene gameScene);
    void OnGameStateExit(GameScene gameScene);
    void SetGameState(GameScene gameScene, GameState gameState);
    void Tick(GameScene gameScene);
}