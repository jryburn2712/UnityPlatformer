
class TitleMenuState : GameState
{
    public const string titleMenuSceneName = "TitleMenu";

    public override void OnGameStateEnter(GameState previousGameState)
    {
        base.OnGameStateEnter(previousGameState);
        gameManager.LoadTitleMenu();
    }
}

