public interface IGameState
{
    void OnGameStateEnter(GameState previousGameState);
    void OnGameStateExit();
    void SetGameState(GameState gameState);
}