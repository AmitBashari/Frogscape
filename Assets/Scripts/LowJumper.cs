using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(ConstantMove))]
public class LowJumper : MonoBehaviour
{
    public float JumpVelocity = 10;
    public float FallMultiplier = 2.5f;

    Rigidbody rb;
    ConstantMove move;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        move = GetComponent<ConstantMove>();
    }

    private void Update()
    {
        if (rb.velocity.y < move.Speed.z) // Makes the "Fall" feel more juicy
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (FallMultiplier - 1) * Time.deltaTime;
        }
       
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "LowJump")
        {
            Debug.Log("We Hit A Low Jumper");
            rb.velocity += Vector3.up * JumpVelocity;
         

        }
    }
}
