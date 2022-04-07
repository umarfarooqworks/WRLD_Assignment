using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wrld.Space;
public class PLayerController : MonoBehaviour
{
    private float initialLatitude = 37.7858f; //initial latitude
    private float initialLongitude = -122.401f; //initial longitude

    [SerializeField] private float moveSpeed = 100f;
    [SerializeField] private float rotateSpeed = 2f;

    private float nextFire;
    public float fireRate = 0.25f; // Number in seconds which controls how often the player can fire


    public GameObject BulletPool; //Bullet Pool Object Reference

    void Update()
    {
//        if (Input.GetKey(KeyCode.F) && Time.time > nextFire)
//        {
//            nextFire = Time.time + fireRate;
////            GameObject bullet = BulletPool.GetComponent<ObjectPool>().GetPooledObject();
//            if (bullet != null)  //Unused bullet found
//            {
//                bullet.transform.position = transform.position;
//                bullet.transform.rotation = transform.rotation;
//                bullet.SetActive(true);
//            }
//        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //  this.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);  // AirCraft Simple Movement

            // AirCraft Movement with SetOriginMethod
            initialLatitude = initialLatitude + 0.00011f;
            LatLongAltitude lla = new LatLongAltitude(initialLatitude, initialLongitude, 10);
            Wrld.Api.Instance.SetOriginPoint(lla);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            //   this.transform.Translate(Vector3.back * Time.deltaTime * moveSpeed); // AirCraft Simple Movement

            // AirCraft Movement with SetOriginMethod
            initialLatitude = initialLatitude - 0.00011f;
            LatLongAltitude lla = new LatLongAltitude(initialLatitude, initialLongitude, 10);
            Wrld.Api.Instance.SetOriginPoint(lla);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //   this.transform.Rotate(Vector3.up, -rotateSpeed); // AirCraft Simple Rotation

            // AirCraft Movement with SetOriginMethod
            initialLongitude = initialLongitude - 0.00011f;
            LatLongAltitude lla = new LatLongAltitude(initialLatitude, initialLongitude, 10);
            Wrld.Api.Instance.SetOriginPoint(lla);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //    this.transform.Rotate(Vector3.up, rotateSpeed); // AirCraft Simple Rotation

            // AirCraft Movement with SetOriginMethod
            initialLongitude = initialLongitude + 0.00011f;
            LatLongAltitude lla = new LatLongAltitude(initialLatitude, initialLongitude, 10);
            Wrld.Api.Instance.SetOriginPoint(lla);
        }

    }
}