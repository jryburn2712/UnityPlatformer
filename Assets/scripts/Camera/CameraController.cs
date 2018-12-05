using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    private GameObject background;
    //private Vector3 offset;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        background = GameObject.FindWithTag("Background");
        //offset = transform.position - player.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        
        /* Set the camera's x position to match the character's x position. Leave y at 0 and keep the z the same.
        /  This will follow the character horizontally but not vertically.
        /
        /  Set the background to match the camera's transform, so the background will be locked to the camera.
        /  The background would not show up when it had the same z value as the camera, so 1 is added to it to make
        /  sure that it's in front of the camera.
        */
        Vector3 newPosition = new Vector3(player.transform.position.x, 0, transform.position.z);
        transform.position = newPosition;
        background.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
    }
}
