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
        this.GetComponent<TMP_Text>().SetText("Stats from most recent run");
        for (i = 0; checkpointLogger.GetComponent<CheckpointPlugin>().LoadTimeTest(i) != -1; i++)
        {
            foundCheckpoint = true;
            this.GetComponent<TMP_Text>().SetText(this.GetComponent<TMP_Text>().text + "\nCheckpoint " + (i + 1) + ": " + checkpointLogger.GetComponent<CheckpointPlugin>().LoadTimeTest(i).ToString("F2") + "s");
            totalTime += checkpointLogger.GetComponent<CheckpointPlugin>().LoadTimeTest(i);
            Debug.Log(checkpointLogger.GetComponent<CheckpointPlugin>().LoadTimeTest(i));
            if(i == 5)
            {
                finished = true;
            }
        }

        if (finished)
        {
            this.GetComponent<TMP_Text>().SetText(this.GetComponent<TMP_Text>().text + "\nTotal Time: " + totalTime.ToString("F2") + "s");
        }
        else if (foundCheckpoint)
        {
            this.GetComponent<TMP_Text>().SetText(this.GetComponent<TMP_Text>().text + "\nYou found " + i + " checkpoints after " + totalTime.ToString("F2") + " seconds");
        }
        else
        {
            this.GetComponent<TMP_Text>().SetText(this.GetComponent<TMP_Text>().text + "\nYou didn't even find 1 checkpoint :(");
        }
        totalTime = 0.0f;
    }
}
