using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgreedOffer : MonoBehaviour
{
    public GameObject envelope;
    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(Agreed);


    }

    public void Agreed()
    {
        GameObject.Find("ManagerStock").GetComponent<NewDay>().agentX = true;
        GameObject.Find("QueueControll").GetComponent<HumanQueue>().humanList[0].GetComponent<FirstDialog>().AgreedClockMoney();
        GameObject.Find("QueueControll").GetComponent<HumanQueue>().HumanExit();
        
        Destroy(envelope);
    }
}
