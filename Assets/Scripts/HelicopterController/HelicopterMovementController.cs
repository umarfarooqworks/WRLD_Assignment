using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wrld.Space;

public class HelicopterMovementController : MonoBehaviour
{
    public InputHandler HeliInputs;
    [SerializeField]
    int TurnSpeed = 2;
    [SerializeField]
    int MoveSpeed = 2;


    void Start()
    {
        HeliInputs.HorizontalInput += RotateHelicopter;
        HeliInputs.VerticalInput += MoveVertically;
    }

    private void OnDisable()
    {
        HeliInputs.HorizontalInput -= RotateHelicopter;
        HeliInputs.VerticalInput += MoveVertically;
    }

    void RotateHelicopter(float angle)
    {
        transform.Rotate(Vector3.up, angle * TurnSpeed  * Time.deltaTime);
    }

    void MoveVertically(float val)
    {
        transform.Translate(Vector3.forward * val * MoveSpeed * Time.deltaTime, Space.Self);
//        MoveUsingSetOriginPoint(val);
    }

    private float initialLatitude = 37.7858f; //initial latitude
    private float initialLongitude = -122.401f; //initial longitude

    void MoveUsingSetOriginPoint(float val)
    {
        initialLatitude = initialLatitude +  (0.00011f * val);
        LatLongAltitude lla = new LatLongAltitude(initialLatitude, initialLongitude, 10);
        Wrld.Api.Instance.SetOriginPoint(lla);
    }
}
