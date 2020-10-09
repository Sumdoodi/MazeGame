using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingScript : MonoBehaviour
{
    public GameObject block;
    public float fallSpeed = 10.0f;
    public float riseSpeed = 2.0f;

    bool falling = false;
    bool rising = false;
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = block.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(falling == true)
        {
            //Causes block to fall
            block.transform.position -= new Vector3(0.0f, fallSpeed * Time.deltaTime, 0.0f);
            if(block.transform.position.y <= 1.0f)
            {
                falling = false;
                rising = true;
            }
        }
        else if (rising == true)
        {
            //Raises the block to initial position
            block.transform.position += new Vector3(0.0f, riseSpeed * Time.deltaTime, 0.0f);
            if(block.transform.position.y >= startPos.y)
            {
                rising = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Sets block to fall if it is not in a rising state
        if (rising == false)
        {
            falling = true;
        }
    }
}
