using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{
    public GameState GameState;
    public Dictionary<GameStateType, GameState> gameStates;
    
    // Use this for initialization
    void Start ()
    {
        gameStates = initGameStates();
        GameState = gameStates[GameStateType.NEWGAME];
    }
	
	// Update is called once per frame
	void Update ()
    {
        GameState.Tick(this);
	}

    private Dictionary<GameStateType, GameState> initGameStates()
    {
        Dictionary<GameStateType, GameState> gameStates = new Dictionary<GameStateType, GameState>();
        gameStates[GameStateType.NEWGAME] = new NewGameState();
        gameStates[GameStateType.PLAYGAME] = new NewGameState();
        gameStates[GameStateType.GAMEOVER] = new GameOverState();

        return gameStates;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public string GetCurrentSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }
}