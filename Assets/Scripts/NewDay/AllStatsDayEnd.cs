using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using SimpleLocalizator;

public class AllStatsDayEnd : MonoBehaviour
{
    public AdderMoneyCount moneyAdder;
    public AdderMoneyCount taxesAdder;
    public AdderMoneyCount partsAdder;
    public AdderMoneyCount anotherAdder;

    public List<AdderMoneyCount> adderList = new List<AdderMoneyCount>();


    public void Awake()
    {
        adderList.Add(moneyAdder);
        adderList.Add(taxesAdder);
        adderList.Add(partsAdder);
        adderList.Add(anotherAdder);

    }
    public void ClearAdder()
    {
        for(int  i = 0; i < adderList.Count; i++)
        {
            adderList[i].currentMoney = 0;
            adderList[i].GetComponent<TextMeshProUGUI>().text = "0";
        }

        
    }

    public void ChangerAdder(int adder, int count)
    {
        adderList[adder].ChangeMoney(count);
    }
    
}
