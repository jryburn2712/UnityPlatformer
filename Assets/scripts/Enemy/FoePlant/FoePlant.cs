﻿
using System.Collections;
using UnityEngine;

class FoePlant : MonoBehaviour
{
    private Player player;

    private float previousVelocityY;

    void Start()
    {
        player = GameManager.Instance.player;
    }

    void Update()
    {
        //Set the previous velocity that will be used in the collision triggger events
        previousVelocityY = player.CachedRigidBody.velocity.y;

        if (transform.childCount == 0) //The plant is dead, explosion animation is playing.
        {
            //Wait a few seconds for the animation to finish then destroy this game object
            StartCoroutine(cleanup());
        }

    }

    //Called from DetectPlantHeadHit script
    public void OnHeadCollision(Collision2D other)
    {
        // Only kill the plant if the player was falling. By the time this is called, the player will have already bounced
        // off the plant's head, so his current velocity will be higher than it was the previous frame when he was falling 
        // (a.k.a. somewhere below zero). The key here is the previous y velocity. If it was below 0, we know he was falling.
        if (previousVelocityY < player.CachedRigidBody.velocity.y)
        {
            disablePlant();
            GetComponent<Animator>().Play("plant_explo");
        }

    }

    //Called from DetectPlantBodyHit script
    public void OnBodyCollision(Collision2D other)
    {
        player.playerHealth -= 100;


        //Only knock the player back if he's not dead (a.k.a. he/she has greater than 0 health)
        if (player.playerHealth > 0)
        {
            //Player died to enemy, set the death type in DeathState
            ((DeathState)player.states[StateType.DEATH]).SetDeathType(DeathType.ENEMY);

            player.State.SetState(player, player.states[StateType.KNOCKED]);
        }
    }

    private IEnumerator cleanup()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

    private void disablePlant()
    {
        //Destroy the children (hitboxes) of the plant while the explosion is playing.
        //We can't just destroy the entire plant object yet because we want the explosion
        //to finish playing before we destroy it
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}

