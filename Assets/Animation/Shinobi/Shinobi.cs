using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shinobi : MonoBehaviour
{
    public RuntimeAnimatorController shinobi;
    
    public void Start()
    {
        GameObject.Find("QueueControll").GetComponent<HumanQueue>().humanList[0].GetComponent<Animator>().runtimeAnimatorController = shinobi;
        GameObject.Find("QueueControll").GetComponent<HumanQueue>().HumanExit();
       
        Destroy(gameObject, 1f);
        
    }
}
