using UnityEngine;


/*
 * Main player script
 */

public class Player : MonoBehaviour {

    [SerializeField]
    private float jumpForce = 500;
    
    public float MoveX { get; set; }

    public float PlayerSpeed = 10;

    public bool IsMoving { get; set; }

    public bool FacingRight = false;

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
}
