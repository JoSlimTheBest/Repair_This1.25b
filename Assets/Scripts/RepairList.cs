using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairList : MonoBehaviour
{
    public GameObject place1;
    public GameObject place2;
    public BasketPhones basketPh;
    public GameObject prefabPhoneDiscription;
    public bool activeNow;

    public Image slotHuman;
    public Sprite spriteHuman;
    
    public void CheckRepairPhone()
    {
        
        CloseTable();
        activeNow = true;
        for (int i = 0; i<basketPh.repairPhone.Count; i++)
        {
            if (i < 5)
            {
                GameObject disc = Instantiate(prefabPhoneDiscription, place1.transform);
                disc.GetComponent<RectTransform>().localPosition = new Vector3(0, -i * 85);
                disc.GetComponent<PhoneRepairDiscription>().Init(basketPh.repairPhone[i].GetComponent<BrokenPhone>());
            }
            else
            {
                GameObject disc = Instantiate(prefabPhoneDiscription, place2.transform);
                disc.GetComponent<RectTransform>().localPosition  = new Vector3(0, - (i-5) * 85);
                disc.GetComponent<PhoneRepairDiscription>().Init(basketPh.repairPhone[i].GetComponent<BrokenPhone>());
            }
            
        }
    }

    public void CloseTable()
    {
        activeNow = false;
        foreach (RectTransform child in place1.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (RectTransform child in place2.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
