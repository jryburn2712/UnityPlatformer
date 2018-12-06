using System.Collections.Generic;
using UnityEngine;

/*
 * Main player script
 */

public class Player : MonoBehaviour 
{
    //Used to determine which animations should be used
    public CharacterGender gender { get; set; }

    //Change this to increase or decrease character jump speed
    public float jumpForce = 10.0f;

    [HideInInspector]public bool isFacingLeft = false;

    public float PlayerSpeed = 300.0f;

    public int playerHealth = 300;

    public Dictionary<StateType, State> states;

    public State State { get; set; }

    [HideInInspector]public Animator playerAnimator;

    [HideInInspector]public Rigidbody2D CachedRigidBody;

    // Use this for initialization
    void Start ()
    {

        //For now, hard code the character's gender. This will be changed when a charcter select screen is added.
        gender = new Female();

        playerAnimator = GetComponent<Animator>();

        states = initStates();

        //Character will start idle
        State = states[StateType.IDLE];

        //Characters Rigidbody component will be cached as a variable
        CachedRigidBody = GetComponent<Rigidbody2D>();
    }    

      
	// Update is called once per frame
	void Update ()
    {
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
        states[StateType.ATTACK] = new AttackState();
        states[StateType.DEATH] = new DeathState();

        return states;
    }

    public string getIdleAnimName()
    {
        return gender.getIdleAnimName();
    }

    public string getWalkAnimName()
    {
        return gender.getWalkAnimName();
    }

    public string getAttackAnimName()
    {
        return gender.getAttackAnimName();
    }

    public string getDeathAnimName()
    {
        return gender.getDeathAnimName();
    }
}