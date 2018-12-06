using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelect : MonoBehaviour
{
    private GameScene gameScene;
    private GameObject player;
    private Player _player;

    // Use this for initialization
    void Start ()
    {
        gameScene = GetComponent<GameScene>();
        player = GameObject.FindWithTag("Player");
        _player = (Player)player.GetComponent(typeof(Player)); 
    }

    // Update is called once per frame
    void Update ()
    {
        if (_player.isDead == true)
        {
            gameScene.GameState.OnGameOver(gameScene);
            _player.isDead = false;
        }
    }
}