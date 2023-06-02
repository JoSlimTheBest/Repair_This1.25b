using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineShaderTake : MonoBehaviour
{
    public float current;
    private bool active;
    private float timeDelay = 0.25f;

    
    public float timeUnlimit;
    public void OutlineActive()
    {
        GetComponent<SpriteRenderer>().material.SetFloat("_OutlineWidth", current);
        active = true;
        timeDelay = 0.1f;
    }

    public void ChangeColor(Color colorGive)
    {
        GetComponent<SpriteRenderer>().material.SetColor("_OutlineColor", colorGive);
       
    }

    public void LimitTime(float count)
    {
        timeUnlimit = count;
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {

        if (timeUnlimit > 0)
        {
            timeUnlimit -= 1*Time.deltaTime;
            GetComponent<SpriteRenderer>().material.SetFloat("_OutlineWidth", current);
            return;
        }
        if (active == true)
        {
            timeDelay -= 1 * Time.deltaTime;
            if (timeDelay < 0)
            {
                active = false;
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().material.SetFloat("_OutlineWidth", 0);
        }
      
    }
}
