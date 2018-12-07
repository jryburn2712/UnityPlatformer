using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameState : GameState
{
    private string newSceneName = "Bonus1";

    public override void OnGameStateEnter(GameState previousGameState)
    {
        base.OnGameStateEnter(previousGameState);
        
        gameManager.LoadScene(newSceneName);
    }
}