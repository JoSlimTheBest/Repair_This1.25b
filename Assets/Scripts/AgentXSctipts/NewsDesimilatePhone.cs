using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsDesimilatePhone : MonoBehaviour
{
    public int checkID;
    void Start()
    {
      List<GameObject> dest =  GameObject.Find("BasketBrokenPhone").GetComponent<BasketPhones>().repairPhone;

        for(int i = 0; i < dest.Count;i++)
        {
            if(dest[i].GetComponent<BrokenPhone>().peopleID == checkID)
            {
                dest[i].GetComponent<BrokenPhone>().desimilatephone = true;
            }
        }
    }

   
}
