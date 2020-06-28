using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody),typeof(ConstantMove))] // if the unit who has this script doesn't have RB - unity will show an "error" message
public class SpeedPads : MonoBehaviour
{
    [Header("Speed Boost")]
    public float SpeedBoostValue = 20f;
    public float MediumSpeedMultiplier = 1.5f;
    public float HighSpeedMultiplier = 3f;
    public float SpeedDecayValue = 5f;

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
        if (collider.gameObject.tag == "SpeedPadLow")
        {
            Debug.Log("We Hit A Speed Pad Low");
            rb.velocity += Vector3.forward * SpeedBoostValue;
        }

        if (collider.gameObject.tag == "SpeedPadMedium")
        {
            Debug.Log("We Hit A Speed Pad Medium");
            rb.velocity += Vector3.forward * SpeedBoostValue * MediumSpeedMultiplier;
        }

        if (collider.gameObject.tag == "SpeedPadHigh")
        {
            Debug.Log("We Hit A Speed Pad High");
            rb.velocity += Vector3.forward * SpeedBoostValue * HighSpeedMultiplier;
        }


    }
}
