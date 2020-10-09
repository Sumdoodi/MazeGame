using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine.UI;

public class CheckpointPlugin : MonoBehaviour
{
    const string DLL_NAME = "MidtermDLL";
    
    //Imports functions
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

    //Saves checkpoint
    public void SaveTimeTest(float checkpointTime)
    {
        SaveCheckpointTime(checkpointTime);
    }

    //Loads checkpoint
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

    //Loads total time
    public float LoadTotalTimeTest()
    {
        return GetTotalTime();
    }

    //Resets checkpoint
    public void ResetLoggerTest()
    {
        ResetLogger();
    }
}
