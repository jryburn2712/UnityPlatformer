
using System.Collections;
using UnityEngine;

class FoePlant : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
        if (transform.childCount == 0)
        {
            //The death animation is playing. Wait a few seconds and then destroy this game object
            StartCoroutine(cleanup());
        }
    }

    private IEnumerator cleanup()
    {
        yield return new WaitForSeconds(5);
        Debug.Log("Destroying plant");
        Destroy(gameObject);
    }
}

