using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(ConstantMove))]
public class BackwardsPushers : MonoBehaviour
{
    [Header("Backwards Force")]
    public float PushBackValue = 20f;
    public float MediumPushMultiplier = 1.5f;
    public float HardPushMultiplier = 3f;
    public float SpeedIncreaseValue = 5f;

    Vector3 PlayerSpeed;
    Rigidbody rb;
    ConstantMove move;

    private float overAllBackwardsPush;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        move = GetComponent<ConstantMove>();
    }

    private void Update()
    {
        PlayerSpeed = rb.velocity;


        if (rb.velocity.z < move.Speed.z)
        {
            rb.velocity += Vector3.forward * SpeedIncreaseValue * Time.deltaTime;
        }

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "SoftBackwardsPusher")
        {
            overAllBackwardsPush =  PushBackValue + PlayerSpeed.z;    
            Debug.Log("We Hit A Soft Backwards Pusher");
            rb.velocity += Vector3.back * overAllBackwardsPush;
        }

        if (collider.gameObject.tag == "MediumBackwardsPusher")
        {
            overAllBackwardsPush = (PushBackValue * MediumPushMultiplier) + PlayerSpeed.z;
            Debug.Log("We Hit A Medium Backwards Pusher");
            rb.velocity += Vector3.back * overAllBackwardsPush;
        }

        if (collider.gameObject.tag == "HardBackwardsPusher")
        {
            overAllBackwardsPush = (PushBackValue * HardPushMultiplier) + PlayerSpeed.z;
            Debug.Log("We Hit A Hard Backwards Pusher");
            rb.velocity += Vector3.back * overAllBackwardsPush;
        }
    }
}
