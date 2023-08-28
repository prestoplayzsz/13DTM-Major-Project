using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    public GameObject UIRacePanel;

    public Text UITextCurrentLap;
    public Text UITextCurrentTime;
    public Text UITextLastLapTime;
    public Text UITextBestLapTime;

    public Player UpdateUIForPlayer;

    private int currentLap = -1;
    private float currentLapTime;
    private float lastLapTime;  
    private float bestLapTime;
    
    // Update is called once per frame
    void Update()
    {
        if (UpdateUIForPlayer == null)
            return;

        // asks if the current lap and the lap displayed are the same
        if (UpdateUIForPlayer.CurrentLap != currentLap)
        {
            // sets them the same
            currentLap = UpdateUIForPlayer.CurrentLap;
            UITextCurrentLap.text = $"Lap: {currentLap}";
        }

        // asks if the current lap time and the lap time displayed are the same
        if (UpdateUIForPlayer.CurrentLapTime != currentLapTime)
        {
            // sets them the same and displays in 00:00:00 time
            currentLapTime = UpdateUIForPlayer.CurrentLapTime;
            UITextCurrentTime.text = $"Time: {(int)currentLapTime / 60}:{(currentLapTime) % 60:00.000}";
        }
        // asks if the last lap time and the lap time displayed are the same
        if (UpdateUIForPlayer.LastLapTime != lastLapTime)
        {
            // sets them the same and displays in 00:00:00 time
            lastLapTime = UpdateUIForPlayer.LastLapTime;
            UITextLastLapTime.text = $"Last: {(int)lastLapTime / 60}:{(lastLapTime) % 60:00.000}";
        }
        // asks if the best lap time and the lap time displayed are the same
        if (UpdateUIForPlayer.BestLapTime != bestLapTime)
        {
            // sets them the same and displays in 00:00:00 time
            bestLapTime = UpdateUIForPlayer.BestLapTime;
            UITextBestLapTime.text = bestLapTime < 1000000 ? $"Best: {(int)bestLapTime / 60}:{(bestLapTime) % 60:00.000}" : "BEST: NONE";
        }
    }
}
