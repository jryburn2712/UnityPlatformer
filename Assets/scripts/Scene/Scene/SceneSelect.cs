using UnityEngine;


public class SceneSelect : MonoBehaviour
{
    private GameManager gameManager;
    private GameObject player;
    private Player _player;

    // Use this for initialization
    void Start ()
    {
        gameManager = GetComponent<GameManager>();
        player = GameObject.FindWithTag("Player");
        _player = (Player)player.GetComponent(typeof(Player)); 
    }

    // Update is called once per frame
    void Update ()
    {
        if (_player.isDead == true)
        {
            _player.isDead = false;
        }
    }
}