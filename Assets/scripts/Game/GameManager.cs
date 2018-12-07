using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager
{
    //debug for loading scenes from the editor
    public static bool DEBUG = true;

    //This script is a Singleton. It needs to persist across multiple Scenes and there should only
    //ever be one instance of it
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
                instance.init();
            }
            return instance;
        }
    }

    public Player player;

    public GameState GameState;
    public Dictionary<GameStateType, GameState> gameStates;

    //Empty constructor
    private GameManager() { }

    private void init()
    {
        gameStates = initGameStates();
        if (GameState == null)
        {
            /*
             * Normally, the GameState would always be set to TitleMenuState when the game starts.
             * However, since we'll be starting Scenes directly from the Unity editor, we need 
             * to make sure that the GameState is set to PlayGameState if its a normal level. This
             * can be removed for the final game.
             */ 
            if (SceneManager.GetActiveScene().name.Equals(TitleMenuState.titleMenuSceneName))
            {
                GameState = gameStates[GameStateType.TITLEMENU];
            } else  
            {
                GameState = gameStates[GameStateType.PLAYGAME];
            }
            
        }
    }    	

    private Dictionary<GameStateType, GameState> initGameStates()
    {
        Dictionary<GameStateType, GameState> gameStates = new Dictionary<GameStateType, GameState>();
        gameStates[GameStateType.TITLEMENU] = new TitleMenuState();
        gameStates[GameStateType.PAUSED] = new PauseGameState();
        gameStates[GameStateType.PLAYGAME] = new PlayGameState();
        gameStates[GameStateType.GAMEOVER] = new GameOverState();

        return gameStates;
    }

    public void setPlayer(Player player)
    {
        this.player = player;
    }

    public void LoadTitleMenu()
    {
        if (!SceneManager.GetActiveScene().name.Equals(TitleMenuState.titleMenuSceneName)) 
        {
            SceneManager.LoadScene(TitleMenuState.titleMenuSceneName);
        }
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