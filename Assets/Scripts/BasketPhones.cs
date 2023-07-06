using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketPhones : MonoBehaviour
{
    public List<GameObject> repairPhone = new List<GameObject>();
    public List<Sprite> repairHumanPhoto = new List<Sprite>();
    public int payingMoney;
    public RepairList list;
    public GameObject sign;
    

    public Sprite modelA;
    public Sprite modelM;
    public Sprite modelS;

    public void AddRepairPhone(GameObject phone,Sprite humanPhoto)
    {

        repairPhone.Add(phone);
        repairHumanPhoto.Add(humanPhoto);
        phone.transform.parent = transform;
        phone.transform.position = transform.position + new Vector3(10, 0, 0);
        
        if(list.activeNow == true)
        {
            list.CloseTable();
            list.CheckRepairPhone();
        }
        else
        {
            sign.SetActive(true);
            
        }

        
        
    }
    public void CheckRepair(string model,int part)
    {
        for(int i = 0; i < repairPhone.Count; i++)
        {
            if(repairPhone[i].GetComponent<BrokenPhone>().model == model)
            {
                if( repairPhone[i].GetComponent<BrokenPhone>().brockenPart == part)
                {
                    sign.SetActive(true);
                    

                }
            }
        }
       
    }

    public void Disamilate(int indexPeople)
    {
        for (int i = 0; i < repairPhone.Count; i++)
        {
            if(repairPhone[i].GetComponent<BrokenPhone>().peopleID == indexPeople)
            {
                Destroy(repairPhone[i], 1f);
                repairPhone.Remove(repairPhone[i]);
                repairHumanPhoto.Remove(repairHumanPhoto[i]);
                if (list.activeNow == true)
                {
                    list.CloseTable();
                    list.CheckRepairPhone();
                }
               
            }
        }

    }

    public GameObject RemovePhone(int index)
    {
        for(int i = 0; i < repairPhone.Count; i++)
        {
            if(repairPhone[i].GetComponent<BrokenPhone>().index == index)
            {
                GameObject replace = repairPhone[i];
                repairPhone.Remove(repairPhone[i]);
                repairHumanPhoto.Remove(repairHumanPhoto[i]);


                if (list.activeNow == true)
                {
                    list.CloseTable();
                    list.CheckRepairPhone();
                }
                else
                {
                   
                }
                return replace;

            }

        }
        return null;
    }

}
