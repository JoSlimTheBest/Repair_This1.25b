using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{

    public bool alive = false;
    public float timeDestroy;
    private void Start()
    {
        if (alive == true)
        {
            
        }
        else
        {
            Destroy(gameObject, timeDestroy);
        }
        
    }

    public void DontKill()
    {

        gameObject.SetActive(true);
        Invoke("SetFalse", timeDestroy);
       
        
    }

    private void SetFalse()
    {
        gameObject.SetActive(false);
    }
}
