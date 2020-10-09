using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointUpdate : MonoBehaviour
{
    public GameObject checkpoint;
    public GameObject text;

    bool visited = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player" && visited == false)
        {
            Debug.Log("Checkpoint!");
            text.SetActive(true);
            visited = true;
            checkpoint.transform.position = this.transform.position;
        }

        if(this.gameObject.name == "End")
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(2);
        }
    }
}
