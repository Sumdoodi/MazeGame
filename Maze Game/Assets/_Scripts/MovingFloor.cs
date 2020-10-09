using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFloor : MonoBehaviour
{

    public GameObject player;
    public Vector3 startPos;
    public Vector3 endPos;
    public float speed = 5.0f;
    public int axis;

    Vector3 move;

    // Update is called once per frame
    void Update()
    {
        if (axis == 1) //X
        {
            positionCheck(this.transform.position.x, endPos.x, startPos.x, ref move.x);
        }
        else if(axis == 2) //Y
        {
            positionCheck(this.transform.position.y, endPos.y, startPos.y, ref move.y);
        }
        else if(axis == 3) //Z
        {
            positionCheck(this.transform.position.z, endPos.z, startPos.z, ref move.z);
        }

        this.transform.position += move * speed * Time.deltaTime;
    }

    private void positionCheck(float pos, float end, float start, ref float move)
    {
        //Generates either x,y,z for the move vector
        if(pos <= end)
        {
            move = 1;
        }
        else if(pos >= start)
        {
            move = -1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Moves player with platform
        if (other.gameObject.name == "Player")
        {
            Debug.Log(move);
            player.GetComponent<CharacterController>().enabled = false;
            player.transform.position += move * speed * Time.deltaTime;
            player.GetComponent<CharacterController>().enabled = true;
        }
    }
}
