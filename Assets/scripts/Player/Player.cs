using UnityEngine;

/*
 * Main player script
 */

public class Player : MonoBehaviour 
{
    //Change this to increase or decrease character jump speed
    public float jumpForce = 500;
    
    //Change this to increase or decrease character movement speed
    public float PlayerSpeed = 10;   

    public bool isJumping;

    public bool isGrounded;

    public bool isFacingLeft = false;

    public Animator playerAnimator;

    public Rigidbody2D CachedRigidBody;

    public Vector2 Movement { get; set; }

    public IState State { get; set; }

    // Use this for initialization
    void Start () {
        //Character will start idle
        playerAnimator = GetComponent<Animator>();
        State = new IdleState();

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

    //Sets the Movement Vector2. Called from InputSystem Update loop.
    public void SetMovement(float x, float y)
    {
        Movement = new Vector2(x, y);
    }

    //Sets Jump by checking the "Jump" input is true and Y Velocity is at 0 to avoid continuous jumps. Called from InputSystem Update loop.
    public void SetJump(bool jump, float verticalVelocity)
    {
        isJumping = jump;
        isGrounded = verticalVelocity == 0;
    }
}