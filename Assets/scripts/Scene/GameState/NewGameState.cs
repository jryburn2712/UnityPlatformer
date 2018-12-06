using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameState : GameState
{
    private string newSceneName = "Bonus1";

    public override void OnGameStateEnter(GameScene gameScene)
    {
        base.OnGameStateEnter(gameScene);
        
        gameScene.LoadScene(newSceneName);
    }

    public override void OnPlayGame(GameScene gameScene)
    {
        base.OnPlayGame(gameScene);

        gameScene.GameState.SetGameState(gameScene, gameScene.gameStates[GameStateType.PLAYGAME]);
        gameScene.GameState.OnPlayGame(gameScene);
    }

    public override void OnGameOver(GameScene gameScene)
    {
        base.OnGameOver(gameScene);

        gameScene.GameState.SetGameState(gameScene, gameScene.gameStates[GameStateType.GAMEOVER]);
        gameScene.GameState.OnGameOver(gameScene);
    }

    public override void Tick(GameScene gameScene)
    {
        NewGame(gameScene);
    }

    public void NewGame(GameScene gameScene)
    {
        if (gameScene.GetCurrentSceneName() != newSceneName)
        {
            gameScene.GameState.SetGameState(gameScene, gameScene.gameStates[GameStateType.NEWGAME]);
        }
    }
}