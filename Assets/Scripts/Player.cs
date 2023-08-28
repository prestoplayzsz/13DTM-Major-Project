using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum ControlType { HumanInput, AI }
    public ControlType controlType = ControlType.HumanInput;

    public float BestLapTime { get; private set; } = Mathf.Infinity;

    public float LastLapTime { get; private set; } = 0;

    public float CurrentLapTime { get; private set; } = 0;

    public int CurrentLap { get; private set; } = 0;

    private float lapTimerTimestamp;
    private int lastCheckpointPassed = 0;

    private Transform checkpointsParent;
    private int checkpointCount;
    private int checkpointLayer;
    private CarController carController;
    
    // called when the script is first loaded and initiallizes variables
    void Awake()
    {
        // Finds the parent objects names checkpoint
        checkpointsParent = GameObject.Find("Checkpoints").transform;
        // keeping track of the checkpoints passed
        checkpointCount = checkpointsParent.childCount;
        // checking the checkpoints under the parent object Checkpoint and whether they have the checkpoint layer
        checkpointLayer = LayerMask.NameToLayer("Checkpoint");
        carController = GetComponent<CarController>();
    }

    // called when the lap starts
    void StartLap()
    {
        // lets the user know when a lap has started
        Debug.Log("StartLap!");
        // adds 1 to the lap
        CurrentLap++;
        // sets last checkpoint passed back to 1
        lastCheckpointPassed = 1;
        // sets the time stamp to the time
        lapTimerTimestamp = Time.time;
    }

    // called when the lap ends
    void EndLap()
    {
        // caluclating the last lap time
        LastLapTime = Time.time - lapTimerTimestamp;
        // checking whether the last lap time was faster than the best lap time and changing it if it is
        BestLapTime = Mathf.Min(LastLapTime, BestLapTime);
        Debug.Log("EndLap  LapTime was " + LastLapTime + " seconds");
    }

    // when a collider collides with another collider
    void OnTriggerEnter(Collider collider)
    {
        // if collides with a collider than isnt a checkpoint collider
        if (collider.gameObject.layer != checkpointLayer)
        {
            return;
        }

        // If this is checkpoint 1...
        if (collider.gameObject.name == "1")
        {
            // ...and we've completed a lap, end the current lap
            if (lastCheckpointPassed == checkpointCount)
            {
                EndLap();
            }

            // If we are on our first lap, or we've passed the last checkpoint - start
            if (CurrentLap == 0 || lastCheckpointPassed == checkpointCount)
            {
                StartLap();
            }
            return;
        }

        // If we've passed the next checkpoint the sequence, update the latest checkpoint
        if (collider.gameObject.name == (lastCheckpointPassed+1).ToString())
        {
            lastCheckpointPassed++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // timer for current lap time
        CurrentLapTime = lapTimerTimestamp > 0 ? Time.time - lapTimerTimestamp : 0;

        // if human is selected controls are usuable
        if (controlType == ControlType.HumanInput)
        {
            carController.Steer = GameManager.Instance.InputController.SteerInput;
            carController.Throttle = GameManager.Instance.InputController.ThrottleInput;
        }
    }
}
