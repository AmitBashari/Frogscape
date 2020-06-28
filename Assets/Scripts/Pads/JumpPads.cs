using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(ConstantMove))]
public class JumpPads : MonoBehaviour
{
    [Header ("Jump Strength")]
    public float JumpVelocity = 10f;
    public float MediumJumpMultiplier = 2f;
    public float HighJumpMultiplier = 4f;

    public float FallMultiplier = 2.5f;

    [Space (10)]

    Rigidbody rb;
    ConstantMove move;

    public void Start()
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
        if (collider.gameObject.tag == "JumpPadLow")
        {
            Debug.Log("We Hit A Jump Pad Low");
            rb.velocity += Vector3.up * JumpVelocity;
        }
        if (collider.gameObject.tag == "JumpPadMedium")
        {
            Debug.Log("We Hit A Jump Pad Medium");
            rb.velocity += Vector3.up * JumpVelocity * MediumJumpMultiplier;
        }

        if (collider.gameObject.tag == "JumpPadHigh")
            {
            Debug.Log("We Hit A Jump Pad High");
            rb.velocity += Vector3.up * JumpVelocity * HighJumpMultiplier;

        }

        
    }
}
