using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    //add camera rotating to debug log

    void Start()
    {
        SetOffset();
        //offset = (transform.position - player.transform.position);
    }


    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }

    [ContextMenu("Set offset")]
    public void SetOffset ()
    {
        offset = (transform.position - player.transform.position);
    }
}

