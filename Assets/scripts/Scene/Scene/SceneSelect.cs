using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelect : MonoBehaviour
{
    public GameObject player;
    private GameScene gameScene;

	// Use this for initialization
	void Start ()
    {

        gameScene = GetComponent<GameScene>();
        player = GameObject.FindWithTag("Player");
         
    }

    // Update is called once per frame
    void Update ()
    {
        if (player.GetComponent<Rigidbody2D>().position.y < -10)
        {
            gameScene.GameState.OnGameOver(gameScene);
        }
    }
}