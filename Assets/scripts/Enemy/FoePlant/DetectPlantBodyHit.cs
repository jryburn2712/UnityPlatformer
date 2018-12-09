using System.Collections;
using UnityEngine;

class DetectPlantBodyHit : MonoBehaviour
{
    Player player;

    void Start()
    {
        player = GameManager.Instance.player;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Player Collided with Plant body");
        
        
    }

}
