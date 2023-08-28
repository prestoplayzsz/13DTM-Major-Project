using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    public bool steer;
    public bool invertSteer;
    public bool power;

    public float SteerAngle { get; set; }
    public float Torque { get; set; }

    private WheelCollider wheelCollider;
    private Transform wheelTransform;

    // Start is called before the first frame update
    void Start()
    {
        // Gets the wheel colliders
        wheelCollider = GetComponentInChildren<WheelCollider>();
        wheelTransform = GetComponentInChildren<MeshRenderer>().GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // sets the wheels transforms and roations to the same as the wheel colliders
        wheelCollider.GetWorldPose(out Vector3 pos, out Quaternion rot);
        wheelTransform.position = pos;
        wheelTransform.rotation = rot;
    }
    
    // Update is called for a specific rate defined in the editor
    private void FixedUpdate()
    {
        // if steer set steer angle to angle of wheel collider and if inverted invert the wheel collider
        if (steer)
        {
            wheelCollider.steerAngle = SteerAngle * (invertSteer? -1 : 1);
        }
        
        // if power set the torque to the torque of the wheels colliders
        if (power)
        {
            wheelCollider.motorTorque = Torque;
        }
    }
}
