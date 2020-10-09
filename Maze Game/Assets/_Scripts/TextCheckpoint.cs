using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCheckpoint : MonoBehaviour
{
    float time = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.active == true)
        {
            time += Time.deltaTime;

            if(time >= 1.5f)
            {
                this.gameObject.SetActive(false);
            }
        }

        if(this.gameObject.active == false)
        {
            time = 0.0f;
        }
    }
}
