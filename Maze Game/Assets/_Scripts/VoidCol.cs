using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidCol : MonoBehaviour
{
    public GameObject player;

    public GameObject lastCheckpoint;
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Dead");

        if(other.gameObject.name == "Player")
        {
            player.GetComponent<CharacterController>().enabled = false;
            player.transform.position = lastCheckpoint.transform.position;
            player.GetComponent<CharacterController>().enabled = true;
        }
    }
}
