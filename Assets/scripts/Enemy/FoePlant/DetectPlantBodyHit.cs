using System.Collections;
using UnityEngine;

class DetectPlantBodyHit : MonoBehaviour
{
    //Parent of this object
    private FoePlant plant;

    void Start()
    {
        plant = transform.parent.gameObject.GetComponent<FoePlant>();
    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        plant.OnBodyCollision(other);                
    }

}
