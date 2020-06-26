using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMove : MonoBehaviour
{
    public Vector3 Speed; // C Sharp convention to use a capital 'S' since this variable is public

    private void Update() 
    {
        transform.Translate(Speed * Time.deltaTime, Space.Self);
    }
}
