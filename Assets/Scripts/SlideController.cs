using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideController : MonoBehaviour
{
    public float Speed;

    private Vector2? _previousMousePosition = null; // we use '_' because it's a private variable. we use ? to allow Vector 2 to be null
    
    private void Update()
    {
        if (Input.GetMouseButton(0))  // GetMouseButtonUp or GetMouseButtonDown adds a bool value for ONE frame only. GetMouseButton Gets it as long as the button is held // 0 means Left mouse button

        {
            Vector2 currentMousePosition = Input.mousePosition; // var means deduce from the vaule I give you, what variable type is should be

            if (_previousMousePosition.HasValue)
            {
                var delta = (_previousMousePosition.Value - currentMousePosition).x;
                transform.Translate(Vector3.left * delta * Speed * Time.deltaTime, Space.Self);
            }

            _previousMousePosition = currentMousePosition;
        }

        else _previousMousePosition = null;
        
    }

}
