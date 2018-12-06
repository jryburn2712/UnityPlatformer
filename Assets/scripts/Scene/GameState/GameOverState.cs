using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverState : GameState
{
    public override void OnGameStateEnter(GameScene gameScene)
    {
        base.OnGameStateEnter(gameScene);        

        gameScene.LoadScene(gameScene.GetCurrentSceneName());
    }

    public override void OnNewGame(GameScene gameScene)
    {
        base.OnGameOver(gameScene);

        gameScene.GameState.SetGameState(gameScene, gameScene.gameStates[GameStateType.NEWGAME]);
        gameScene.GameState.OnNewGame(gameScene);
    }

    public override void OnPlayGame(GameScene gameScene)
    {
        base.OnPlayGame(gameScene);

        gameScene.GameState.SetGameState(gameScene, gameScene.gameStates[GameStateType.PLAYGAME]);
        gameScene.GameState.OnPlayGame(gameScene);
    }

    public override void Tick(GameScene gameScene)
    {
        GameOver(gameScene);
    }

    public void GameOver(GameScene gameScene)
    {

    }
}