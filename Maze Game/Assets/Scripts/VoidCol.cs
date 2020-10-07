using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidCol : MonoBehaviour
{
    public GameObject player;

    public GameObject lastCheckpoint;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Pls");

        if(other.gameObject.name == "Player")
        {
            player.GetComponent<CharacterController>().enabled = false;
            player.transform.position = lastCheckpoint.transform.position;
            player.GetComponent<CharacterController>().enabled = true;
        }
    }
}
