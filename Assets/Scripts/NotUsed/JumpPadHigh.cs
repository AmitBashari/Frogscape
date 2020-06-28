using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(ConstantMove))]
public class JumpPadHigh : MonoBehaviour
{
    //public float JumpVelocity = 100f;
    public float FallMultiplier = 2.5f;

    Rigidbody rb;
    ConstantMove move;

    //private float lowJump;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        move = GetComponent<ConstantMove>();
        //lowJump = JumpPads.JumpVelocity;

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
        if (collider.gameObject.tag == "JumpPadHigh")
        {
            Debug.Log("We Hit A Jump Pad High");
            //rb.velocity += Vector3.up * JumpVelocity;
            //rb.velocity += Vector3.up * lowJump * 4f;



        }
    }
}
