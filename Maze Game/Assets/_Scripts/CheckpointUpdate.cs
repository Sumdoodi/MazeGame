using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class CheckpointUpdate : MonoBehaviour
{
    public GameObject checkpoint;
    public GameObject text;

    bool visited = false;

    static int numScore = 0;
    public GameObject textMeshProUI;
    TextMeshProUGUI textMesh;

    static float lastTime;
    static float checkpointTime;

    private void Start()
    {
        textMesh = textMeshProUI.GetComponent<TextMeshProUGUI>();
        lastTime = Time.time;
        numScore = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Updates checkpoint object to new checkpoint position
        if(other.gameObject.name == "Player" && visited == false)
        {
            text.SetActive(true);
            visited = true;
            checkpoint.transform.position = this.transform.position;

            checkpointTime = Time.time - lastTime;
            lastTime = Time.time;
            //Updates score and checkpoint logger
            int tempScore = 100 - Mathf.RoundToInt(checkpointTime);
            if (tempScore <= 0)
            {
                tempScore = 0;
            }

            numScore += tempScore;
            checkpoint.GetComponent<CheckpointPlugin>().SaveTimeTest(checkpointTime);

            textMesh.text = "Score: " + numScore.ToString();
        }
        
        //Sends you to end scene
        if(this.gameObject.name == "End")
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(2);
        }
    }
}
