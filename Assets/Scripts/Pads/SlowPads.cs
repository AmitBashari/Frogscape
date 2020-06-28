using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(ConstantMove))]
public class SlowPads : MonoBehaviour
{
    [Header("Slow Applied")]   
    public float SlowValue = 10f;
    public float MediumMultiplier = 1.5f;
    public float HeavyMultiplier = 3f;
    public float SpeedIncreaseValue = 4f;

    Rigidbody rb;
    ConstantMove move;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        move = GetComponent<ConstantMove>();
    }

    private void Update()
    {
    
        if (rb.velocity.z < move.Speed.z)
        {
            rb.velocity += Vector3.forward * SpeedIncreaseValue * Time.deltaTime;
        }

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "SlowPadLow")
        {
            if (rb.velocity.z < SlowValue)
            {
                SlowValue = rb.velocity.z - (SlowValue/2);
            }

            Debug.Log("We Hit A Slow Pad Low");
           
            rb.velocity += Vector3.back * SlowValue;


        }

        if (collider.gameObject.tag == "SlowPadMedium")
        {
            if (rb.velocity.z < SlowValue * MediumMultiplier)
            {
                SlowValue = rb.velocity.z / MediumMultiplier - (SlowValue / 2);
            }

            Debug.Log("We Hit A Slow Pad Medium");

            rb.velocity += Vector3.back * SlowValue * MediumMultiplier;

        }

        if (collider.gameObject.tag == "SlowPadHeavy")
        {
            if (rb.velocity.z < SlowValue * HeavyMultiplier)
            {
                SlowValue = rb.velocity.z / HeavyMultiplier - (SlowValue / 2);
            }

            Debug.Log("We Hit A Slow Pad Heavy");

            rb.velocity += Vector3.back * SlowValue * HeavyMultiplier;

        }


    }
    
}
