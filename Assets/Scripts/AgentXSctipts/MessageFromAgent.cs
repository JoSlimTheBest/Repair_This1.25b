using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageFromAgent : MonoBehaviour
{
    private MessageHolder messHold;
    public GameObject messagePrefab;


    public void Start()
    {
        
        messHold = GameObject.Find("ManagerStock").GetComponent<ManagerStock>().mess;
        Invoke("GoMess", 4f);
    }

    public void GoMess()
    {
        messHold.AddMessages(messagePrefab);
        

       
    }
}
