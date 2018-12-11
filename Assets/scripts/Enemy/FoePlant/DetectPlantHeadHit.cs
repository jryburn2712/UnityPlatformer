using System.Collections;
using UnityEngine;

class DetectPlantHeadHit : MonoBehaviour
{
    //Parent of this object
    private FoePlant plant;

    void Start()
    {
        plant = transform.parent.gameObject.GetComponent<FoePlant>();
    }

    void update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {              
        plant.OnHeadCollision(other);
    }

}

