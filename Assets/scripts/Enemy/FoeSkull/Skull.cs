using UnityEngine;

public class Skull : MonoBehaviour {

    private Rigidbody2D cachedRigidBody;


	void Start () {
        cachedRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        
    }
}
