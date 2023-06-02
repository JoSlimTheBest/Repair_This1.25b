using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HusbandVaness : MonoBehaviour
{

    private MessageHolder messHold;
    public GameObject messagePrefab;
    private DoorController door;
    public void Start()
    {
        GameObject.Find("QueueControll").GetComponent<HumanQueue>().HumanExit();
        messHold = GameObject.Find("ManagerStock").GetComponent<ManagerStock>().mess;
        door = GameObject.Find("door").GetComponent<DoorController>();
        Invoke("GoMess", 15f);
    }


    public void GoMess()
    {
        messHold.AddMessages(messagePrefab);
        GameObject vanessa = Resources.Load<GameObject>("ActiveHuman/Vanessa");
        door.HumanInsta(vanessa);
        

        Destroy(gameObject, 2f);
    }
    
}
