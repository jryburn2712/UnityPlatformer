using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCheck : MonoBehaviour {

    private Player player;
    private float playerHeight;
    private float bottomOfScreen;

    void Awake()
    {
        player = GetComponent<Player>();
        playerHeight = player.transform.localScale.y;
        bottomOfScreen = Camera.main.ScreenToWorldPoint(Vector3.zero).y;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //Only run these checks if the player is not already dead.
        if (player.State != player.states[StateType.DEATH])
        {
            //Check if player fell off of map. If the player is more than 3 player heights off the bottom of the screen, he's dead.
            if (player.transform.position.y < bottomOfScreen - (playerHeight * 3))
            {
                //Set the DeathType to Fall
                ((DeathState)player.states[StateType.DEATH]).SetDeathType(DeathType.FALL);
                player.State.SetState(player, player.states[StateType.DEATH]);                
            }
            else if (player.playerHealth <= 0)
            {
                //Player died by losing health. Set DeathType to Enemy
                ((DeathState)player.states[StateType.DEATH]).SetDeathType(DeathType.ENEMY);
                player.State.SetState(player, player.states[StateType.DEATH]);
            }
        }
	}
}
