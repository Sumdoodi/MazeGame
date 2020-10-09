using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsScreen : MonoBehaviour
{

    public GameObject checkpointLogger;
    bool finished = false;
    bool foundCheckpoint = false;
    float totalTime = 0.0f;
    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<TextMeshProUGUI>().text = "Stats from most recent run";

        //Generates checkpoint text and times
        for (i = 0; checkpointLogger.GetComponent<CheckpointPlugin>().LoadTimeTest(i) != -1; i++)
        {
            foundCheckpoint = true;
            this.GetComponent<TextMeshProUGUI>().text += "\nCheckpoint " + (i + 1) + ": " + checkpointLogger.GetComponent<CheckpointPlugin>().LoadTimeTest(i).ToString("F2") + "s";
            totalTime += checkpointLogger.GetComponent<CheckpointPlugin>().LoadTimeTest(i);
            if(i == 5)
            {
                finished = true;
            }
        }

        //Ending message either total time to complete/total time for checkpoints reached/didnt hit any checkpoints
        if (finished)
        {
            this.GetComponent<TextMeshProUGUI>().text += "\nTotal Time: " + totalTime.ToString("F2") + "s";
        }
        else if (foundCheckpoint)
        {
            this.GetComponent<TextMeshProUGUI>().text += "\nYou found " + i + " checkpoints after " + totalTime.ToString("F2") + "s";
        }
        else
        {
            this.GetComponent<TextMeshProUGUI>().text = "\nYou didn't even find 1 checkpoint :(";
        }
        totalTime = 0.0f;
    }
}
