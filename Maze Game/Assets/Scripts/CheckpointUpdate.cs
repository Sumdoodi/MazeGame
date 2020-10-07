using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointUpdate : MonoBehaviour
{
    public GameObject checkpoint;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            Debug.Log("Checkpoint!");
            checkpoint.transform.position = this.transform.position;
        }
    }
}
