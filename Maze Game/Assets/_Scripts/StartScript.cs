using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartScript : MonoBehaviour
{
    public GameObject checkpointLogger;

    public void PlayGame()
    {
        checkpointLogger.GetComponent<CheckpointPlugin>().ResetLoggerTest(); //Resets stats
        SceneManager.LoadScene(1); //Transitions to play scene
    }

    public void StatsScreen()
    {
        SceneManager.LoadScene(2); //Transitions to end scene
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0); // Transition to start scene
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
