using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBackwardsPusher : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Debug.Log("BacwardsPusher Destroyed");
        }
    }

}