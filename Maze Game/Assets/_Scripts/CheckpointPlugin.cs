using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using TMPro;

public class CheckpointPlugin : MonoBehaviour
{
    const string DLL_NAME = "MidtermDLL";
    
    [DllImport(DLL_NAME)]
    private static extern void ResetLogger();

    [DllImport(DLL_NAME)]
    private static extern void SaveCheckpointTime(float RTBC);

    [DllImport(DLL_NAME)]
    private static extern float GetTotalTime();

    [DllImport(DLL_NAME)]
    private static extern float GetCheckpointTime(int index);

    [DllImport(DLL_NAME)]
    private static extern int GetNumCheckpoints();

    float lastTime = 0.0f;
    int numScore = 0;
    Vector3 lastCheckpoint = new Vector3(0.0f, 0.0f, 0.0f);
    public GameObject textMeshPro;
    
    public void SaveTimeTest(float checkpointTime)
    {
        SaveCheckpointTime(checkpointTime);
    }

    public float LoadTimeTest(int index)
    {
        if (index >= GetNumCheckpoints())
        {
            return -1.0f;
        }
        else
        {
            return GetCheckpointTime(index);
        }
    }

    public float LoadTotalTimeTest()
    {
        return GetTotalTime();
    }

    public void ResetLoggerTest()
    {
        ResetLogger();
    }

    // Start is called before the first frame update
    void Start()
    {
        lastTime = Time.time;
        lastCheckpoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != lastCheckpoint)
        {
            float currentTime = Time.time;
            float checkpointTime = currentTime - lastTime;
            lastTime = currentTime;
            int tempScore = 100 - Mathf.RoundToInt(checkpointTime);
            if(tempScore <= 0)
            {
                tempScore = 0;
            }

            numScore += tempScore;
            SaveTimeTest(checkpointTime);
        }

        for(int i = 0; i < 10; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0 + i))
            {
                Debug.Log(LoadTimeTest(i));
            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log(LoadTotalTimeTest());
        }

        textMeshPro.GetComponent<TMP_Text>().SetText("Score: " + numScore.ToString());
        lastCheckpoint = transform.position;
    }

    private void OnDestroy()
    {
        //ResetLoggerTest();
    }
}
