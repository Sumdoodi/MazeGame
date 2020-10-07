using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsScreen : MonoBehaviour
{

    public GameObject checkpointLogger;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; checkpointLogger.GetComponent<CheckpointPlugin>().LoadTimeTest(i) != -1; i++)
        {
            this.GetComponent<TMP_Text>().SetText(this.GetComponent<TMP_Text>().text + "\nCheckpoint " + (i + 1) + ": " + checkpointLogger.GetComponent<CheckpointPlugin>().LoadTimeTest(i));
            Debug.Log(checkpointLogger.GetComponent<CheckpointPlugin>().LoadTimeTest(i));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
