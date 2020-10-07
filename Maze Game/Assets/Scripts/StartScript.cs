using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1); //Transitions to play scene
    }

    public void StatsScreen()
    {
        SceneManager.LoadScene(2); //Transitions to end scene
    }
}
