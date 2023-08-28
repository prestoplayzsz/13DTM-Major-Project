using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    // sets the left and right arrows inputs
    public string inputSteerAxis = "Horizontal";
    // sets the up and down arrows inputs
    public string inputThrottleAxis = "Vertical";

    public float ThrottleInput { get; private set; }
    public float SteerInput { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // activates the cars movemenst depending on the button pressed
        SteerInput = Input.GetAxis(inputSteerAxis);
        ThrottleInput = Input.GetAxis(inputThrottleAxis);

    }
}
