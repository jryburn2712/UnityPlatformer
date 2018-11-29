using UnityEngine;

/*
 * Main player script
 */

public class Player : MonoBehaviour {

    [SerializeField]
    public float jumpForce = 500;
    
    //Change this to increase or decrease character movement speed
    public float PlayerSpeed = 700.0f;

    public Vector2 Movement { get; set; }

    public bool FacingLeft = false;

    public IState State { get; set; }

    public Animator playerAnimator;

    // Use this for initialization
    void Start () {
        //Character will start idle
        playerAnimator = GetComponent<Animator>();
        State = new IdleState();
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
}