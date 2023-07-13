using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{

    public bool alive = false;
    public float timeDestroy;
    private Vector3 startPosition;
    private void Start()
    {
        if (alive == true)
        {
            startPosition = transform.localPosition;
        }
        else
        {
            Destroy(gameObject, timeDestroy);
        }
        
    }

    public void DontKill()
    {
        transform.localPosition = startPosition;
        gameObject.SetActive(true);
        Invoke("SetFalse", timeDestroy);
       
        
    }

    private void SetFalse()
    {
        gameObject.SetActive(false);
    }
}
