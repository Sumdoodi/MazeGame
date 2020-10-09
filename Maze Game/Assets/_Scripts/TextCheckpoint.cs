using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCheckpoint : MonoBehaviour
{
    float time = 0.0f;

    // Update is called once per frame
    void Update()
    {
        //Displays checkpoint reached screen and hides it after 1.5 seconds
        if(this.gameObject.activeSelf == true)
        {
            time += Time.deltaTime;

            if(time >= 1.5f)
            {
                this.gameObject.SetActive(false);
            }
        }

        if(this.gameObject.activeSelf == false)
        {
            time = 0.0f;
        }
    }
}
