using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGameState : GameState
{
    public override void OnGameStateEnter(GameScene gameScene)
    {
        base.OnGameStateEnter(gameScene);
        
    }

    public override void OnNewGame(GameScene gameScene)
    {
        base.OnGameOver(gameScene);

        gameScene.GameState.SetGameState(gameScene, gameScene.gameStates[GameStateType.NEWGAME]);
        gameScene.GameState.OnNewGame(gameScene);
    }

    public override void OnGameOver(GameScene gameScene)
    {
        base.OnGameOver(gameScene);

        gameScene.GameState.SetGameState(gameScene, gameScene.gameStates[GameStateType.GAMEOVER]);
        gameScene.GameState.OnGameOver(gameScene);
    }

    public override void Tick(GameScene gameScene)
    {
        PlayGame(gameScene);
    }

    public void PlayGame(GameScene gameScene)
    {

    }
}