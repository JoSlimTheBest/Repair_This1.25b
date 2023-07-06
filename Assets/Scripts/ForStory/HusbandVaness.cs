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
        GameObject husMessage = messHold.AddMessages(messagePrefab);
        GameObject vanessaLoad = Resources.Load<GameObject>("ActiveHuman/Vanessa");
        GameObject instVanessa = door.HumanInsta(vanessaLoad);
        husMessage.GetComponent<KillVanessa>().vanessa = instVanessa;
        husMessage.GetComponent<KillVanessa>().take = 3;

        Destroy(gameObject, 2f);
    }
    
}
