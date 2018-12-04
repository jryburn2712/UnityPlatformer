using System.Collections.Generic;
using UnityEngine;

/*
 * Main player script
 */

public class Player : MonoBehaviour 
{
    //Change this to increase or decrease character jump speed
    public float jumpForce = 300.0f;

    public bool isFacingLeft = false;

    public float PlayerSpeed = 500.0f;

    public Dictionary<StateType, State> states;

    public State State { get; set; }

    public Animator playerAnimator;

    public Rigidbody2D CachedRigidBody;

    // Use this for initialization
    void Start () {
        //Character will start idle
        states = initStates();
        playerAnimator = GetComponent<Animator>();
        State = states[StateType.IDLE];

        //Characters Rigidbody component will be cached as a variable
        CachedRigidBody = GetComponent<Rigidbody2D>();
    }    

      
	// Update is called once per frame
	void Update () {
        /*
         * Everything the character does will be handled by its current state (idle, moving, jumping, etc...).
         * The state is changed by the InputSystem based on which controls the user presses.
         * 
         */
        State.Tick(this);
	}

    private Dictionary<StateType, State> initStates()
    {
        Dictionary<StateType, State> states = new Dictionary<StateType, State>();
        states[StateType.IDLE] = new IdleState();
        states[StateType.MOVE] = new MoveState();
        states[StateType.JUMP] = new JumpState();

        return states;
    }
        
    
}