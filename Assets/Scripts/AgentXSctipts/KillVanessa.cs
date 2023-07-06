using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillVanessa : MonoBehaviour
{

    public GameObject vanessa;
    public GameObject newsKill;
    private ComputerTime ct;
    public int take;

    public void Start()
    {
        ct = GameObject.Find("QueueControll").GetComponent<ComputerTime>();
    }
    public void Kill()
    {
        if(ct.hours < vanessa.GetComponent<HumanCharacter>().hour)
        {
            Destroy(vanessa);
        }
        else
        {
            if (ct.minute +10 < vanessa.GetComponent<HumanCharacter>().minute)
            {
                Destroy(vanessa);
            }
        }

        GameObject.Find("ManagerStock").GetComponent<NewDay>().news.NextNewsAdd(newsKill);
    }
}
