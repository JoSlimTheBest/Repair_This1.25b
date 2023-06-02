using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RejectOffer : MonoBehaviour
{
    public GameObject envelope;
    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(Reject);


    }

    public void Reject()
    {
        GameObject.Find("ManagerStock").GetComponent<NewDay>().agentX = false;
        GameObject.Find("QueueControll").GetComponent<HumanQueue>().humanList[0].GetComponent<FirstDialog>().DialogDenayOrder();
        GameObject.Find("QueueControll").GetComponent<HumanQueue>().HumanExit();

        Destroy(envelope);
    }
}
