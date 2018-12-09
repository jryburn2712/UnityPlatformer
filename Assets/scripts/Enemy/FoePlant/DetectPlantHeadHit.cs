using System.Collections;
using UnityEngine;

class DetectPlantHeadHit : MonoBehaviour
{
    private Player player;

    void Start()
    {
        player = GameManager.Instance.player;
    }

    void OnCollisionEnter2D(Collision2D other)
    {       
        Debug.Log("Player collided with plant head");
        Debug.Log("Y Vel: " + player.CachedRigidBody.velocity.y);
        disablePlant();
        GetComponentInParent<Animator>().Play("plant_explo");               
    }

    void update()
    {
      
    }

    private void disablePlant()
    {
        //Destroy the children (hitboxes) of the plant while the explosion is playing
        //We can't just destroy the entire plant object yet because we want the explosion
        //to finish playing before we destroy it
        foreach (Transform child in transform.parent.transform)
        {
            Destroy(child.gameObject);
        }        
    }
}

