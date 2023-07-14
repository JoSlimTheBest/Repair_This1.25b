using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverCharacter : MonoBehaviour
{
    public DeliverQue deliverQ;


    private void Start()
    {
        deliverQ = GameObject.Find("ManagerStock").GetComponent<ManagerStock>().deliverQue;
        deliverQ.deliverBoy.Add(gameObject);
    }

    public void Unload()
    {
        deliverQ.deliverBoy.Remove(gameObject);
    }
}
