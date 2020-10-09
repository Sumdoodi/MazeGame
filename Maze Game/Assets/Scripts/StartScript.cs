using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartScript : MonoBehaviour
{
    public GameObject checkpointLogger;

    public void PlayGame()
    {
        SceneManager.LoadScene(1); //Transitions to play scene
        checkpointLogger.GetComponent<CheckpointPlugin>().ResetLoggerTest();
    }

    public void StatsScreen()
    {
        SceneManager.LoadScene(2); //Transitions to end scene
    }
}
