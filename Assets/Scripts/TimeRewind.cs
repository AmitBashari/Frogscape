using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeRewind : MonoBehaviour {

	bool isRewinding = false;

	public float recordTime;
    public float HowHardToShake;

	List<PointInTime> pointsInTime;

	Rigidbody rb;
    Collider col;
    SlideController slide;

    Vector3 accelerationDir;

	// Use this for initialization
	void Start () {
		pointsInTime = new List<PointInTime>();
		rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        slide = GetComponent<SlideController>();
    
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Return)) // Add Here - && NumberOfFlies >=5
			StartRewind(); //Add here - NumberOfFlies - 5
        if (Input.GetKeyUp(KeyCode.Return))
			StopRewind();
            
        /*accelerationDir = Input.acceleration;

        if (accelerationDir.sqrMagnitude >= HowHardToShake)
        {
            StartRewind();
        }
        else
        { 
            StopRewind();
        }
        */
    }

	void FixedUpdate ()
	{
		if (isRewinding)
			Rewind();
		else
			Record();
	}

	void Rewind ()
	{
		if (pointsInTime.Count > 0)
		{
			PointInTime pointInTime = pointsInTime[0];
            transform.position = pointInTime.position;
			transform.rotation = pointInTime.rotation;
            rb.velocity = pointInTime.velocity;

			pointsInTime.RemoveAt(0);
		} else
		{
			StopRewind();
		}
		
	}

	void Record ()
	{
		if (pointsInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
		{
			pointsInTime.RemoveAt(pointsInTime.Count - 1);
		}

        pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation, rb.velocity));
	}

	public void StartRewind ()
	{
		isRewinding = true;
		//rb.isKinematic = true;
        col.enabled = false;
        slide.enabled = false;

	}

	public void StopRewind ()
	{
		isRewinding = false;
		//rb.isKinematic = false;
        col.enabled = true;
        slide.enabled = true;
    }
}
