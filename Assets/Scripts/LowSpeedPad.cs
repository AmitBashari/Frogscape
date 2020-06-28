using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody),typeof(ConstantMove))] // if the unit who has this script doesn't have RB - unity will show an "error" message
public class LowSpeedPad : MonoBehaviour
{
    public float SpeedBoostValue;
    public float SpeedDecayValue;

    Rigidbody rb;
    ConstantMove move;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        move = GetComponent<ConstantMove>();
    }

    private void Update()
    {
        Debug.Log(rb.velocity);
        if (rb.velocity.z > move.Speed.z) // player start speed
        {
            rb.velocity -= Vector3.forward * SpeedDecayValue* Time.deltaTime;
        }


    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "LowSpeedPad")
        {
            Debug.Log("We Hit A LowSpeed");
            rb.velocity += Vector3.forward * SpeedBoostValue;


        }
    }
}
