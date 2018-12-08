using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour {

    //The rigidBody of the platform
    private Rigidbody2D rigidBody;

    //The starting x Position of the platform
    private float startingX;

    //Speed at which it will move
    public float moveSpeed = 200.0f;

    //How far it will move before changing direction
    public float range = 5.0f;

    //The direction the platform is currently moving
    private Direction direction;

    
	// Use this for initialization
	void Start () {

        //Get the platform's RigidBody
        rigidBody = GetComponent<Rigidbody2D>();

        //Get the starting x position
        startingX = transform.position.x;

        //Set initial Direction
        direction = Direction.RIGHT;
	}
	
	// Update is called once per frame
	void Update () {
        checkRange();

		if (direction == Direction.LEFT)
        {
            rigidBody.velocity = Vector2.left * moveSpeed * Time.deltaTime;
        } else
        {
            rigidBody.velocity = Vector2.right * moveSpeed * Time.deltaTime;
        }
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        //Code for when player touches platform (if any)       
    }

    void OnCollisionExit2D(Collision2D other)
    {
        //Code for when player exits platform (if any)
    }

    //Checks if the platform has reached the max travel range
    private void checkRange()
    {       
        if (Mathf.Abs(startingX - transform.position.x) >= range || (transform.position.x <= startingX && direction != Direction.RIGHT))
        {
            FlipDirection();
        } 
    }

    private void FlipDirection()
    {
        if (direction == Direction.LEFT)
        {
            direction = Direction.RIGHT;
        } else
        {
            direction = Direction.LEFT;
        }
    }
}
