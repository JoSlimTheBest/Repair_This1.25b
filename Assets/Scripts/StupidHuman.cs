using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StupidHuman : MonoBehaviour
{
    public void Start()
    {
        GameObject.Find("QueueControll").GetComponent<HumanQueue>().HumanExit();

        Destroy(gameObject, 1f);
    }
}
