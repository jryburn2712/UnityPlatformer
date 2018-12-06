using System.Collections.Generic;
using UnityEngine;

/*
 * Main player script
 */

public class Player : MonoBehaviour 
{
    //Set in the editor
    public Sprite maleSprite, femaleSprite;

    [HideInInspector]public AudioSource playerAudioSource;
    public AudioClip[] maleJumpSounds, femaleJumpSounds;

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

    [HideInInspector] public SpriteRenderer cachedSpriteRenderer;

    void Awake()
    {
        //For now, hard code the character's gender. This will be changed when a charcter select screen is added.
        gender = new Female(this);
        cachedSpriteRenderer = GetComponent<SpriteRenderer>();
        //Set the sprite to be either male or female
        setCharacterSprite();
    }

    // Use this for initialization
    void Start ()
    {
        //Get refernces to necessary objects
        playerAnimator = GetComponent<Animator>();       
        CachedRigidBody = GetComponent<Rigidbody2D>();
        playerAudioSource = GetComponent<AudioSource>();
        

        states = initStates();

        //Character will start idle
        State = states[StateType.IDLE];
        
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

    private void setCharacterSprite()
    {
        if (gender is Male)
        {
            cachedSpriteRenderer.sprite = maleSprite;
        } else
        {
            cachedSpriteRenderer.sprite = femaleSprite;
        }
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

    public AudioClip getJumpAudioClip()
    {
        return gender.getJumpAudio();
    }
}