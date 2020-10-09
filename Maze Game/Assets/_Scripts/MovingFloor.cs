using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFloor : MonoBehaviour
{

    public GameObject player;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float groundDistance = 0.4f;

    public Vector3 startPos;
    public Vector3 endPos;

    public float speed = 5.0f;
    public int axis;

    Vector3 move;
    bool isOnPlatform = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        isOnPlatform = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (axis == 1)
        {
            positionCheck(this.transform.position.x, endPos.x, startPos.x, ref move.x);
        }
        else if(axis == 2)
        {
            positionCheck(this.transform.position.y, endPos.y, startPos.y, ref move.y);
        }
        else if(axis == 3)
        {
            positionCheck(this.transform.position.z, endPos.z, startPos.z, ref move.z);
        }

        this.transform.position += move * speed * Time.deltaTime;
    }

    private void positionCheck(float pos, float end, float start, ref float move)
    {
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
        if (other.gameObject.name == "Player")
        {
            Debug.Log(move);
            player.GetComponent<CharacterController>().enabled = false;
            player.transform.position += move * speed * Time.deltaTime;
            player.GetComponent<CharacterController>().enabled = true;
        }
    }
}
