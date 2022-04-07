using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public event Action<float> TurnInput;
    public event Action<float> HorizontalInput;
    public event Action<float> VerticalInput;

    private void Update()
    {
        if(Input.GetKey(KeyCode.E))
        {
            TurnInput?.Invoke(1);
        }
        else if(Input.GetKey(KeyCode.Q))
        {
            TurnInput?.Invoke(-1);
        }
        else
        {
            TurnInput?.Invoke(0);
        }


        HorizontalInput?.Invoke(Input.GetAxis("Horizontal"));
        VerticalInput?.Invoke(Input.GetAxis("Vertical"));
    }
}
