using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMove : MonoBehaviour
{
    public Vector3 Speed; // C Sharp convention to use a capital 'S' since this variable is public
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Speed);

    }

}
