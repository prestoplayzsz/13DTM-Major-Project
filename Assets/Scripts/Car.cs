using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{ 
    public Transform centerOfMass;
    public float motorTorque = 100f;
    public float maxSteer = 20f;
    
    public float Steer { get; set; }
    public float Throttle { get; set; }


    private Rigidbody _rigidbody;
    private Wheel[] wheels;

    void Start()
    {
        // Get the wheels
        wheels = GetComponentsInChildren<Wheel>();
        // sets the rigidbody on the center of mass
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.centerOfMass = centerOfMass.localPosition;
    }

    void FixedUpdate()
    {
        
    }
    void Update()
    {
        
        // sets variables for the wheels
        foreach (var wheel in wheels)
        {
            wheel.SteerAngle = Steer * maxSteer;
            wheel.Torque = Throttle * motorTorque;
        }

    }
}
