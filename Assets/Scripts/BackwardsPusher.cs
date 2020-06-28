using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(ConstantMove))]
public class BackwardsPusher : MonoBehaviour
{
    public float PushBackValue;
    public float SpeedIncreaseValue;

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
        if (collider.gameObject.tag == "BackwardsPusher")
        {


            overAllBackwardsPush =  PushBackValue + PlayerSpeed.z;
            

            Debug.Log("We Hit A SlowPad");

            rb.velocity += Vector3.back * overAllBackwardsPush;


        }
    }
}
