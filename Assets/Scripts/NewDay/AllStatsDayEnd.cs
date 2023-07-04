using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using SimpleLocalizator;

public class AllStatsDayEnd : MonoBehaviour
{
    

    public List<AdderMoneyCount> adderList = new List<AdderMoneyCount>();

    public GameObject prefabAdder;


    public void Awake()
    {
        

    }
    public void ClearAdder()
    {
        for(int  i = 0; i < adderList.Count; i++)
        {
            Destroy(adderList[i].gameObject);
        }

        adderList = new List<AdderMoneyCount>();

        
    }

    public void ChangerAdder(int adder, int count)
    {
        adderList[adder].ChangeMoney(count);
    }


    public void InstAdder(string nameEng,string nameRus,int countMoney)
    {
        if(LanguageManager.currentLang == Language.English)
        {
            for(int i = 0; i < adderList.Count; i++)
            {
                if(adderList[i].discription.text == nameEng)
                {
                    ChangerAdder(i, countMoney);
                    return;
                }
            }
            GameObject adderOn = Instantiate(prefabAdder, transform);
            adderOn.GetComponent<AdderMoneyCount>().discription.text = nameEng;
            adderOn.transform.localPosition += new Vector3(0, -50 * adderList.Count, 0);
            adderList.Add(adderOn.GetComponent<AdderMoneyCount>());
            ChangerAdder(adderList.Count - 1, countMoney);


        }
        else
        {
            for (int i = 0; i < adderList.Count; i++)
            {
                if (adderList[i].discription.text == nameRus)
                {
                    ChangerAdder(i, countMoney);
                    return;
                }
            }
            GameObject adderOn = Instantiate(prefabAdder, transform);
            adderOn.GetComponent<AdderMoneyCount>().discription.text = nameRus;
            adderOn.transform.localPosition += new Vector3(0, -50 * adderList.Count, 0);
            adderList.Add(adderOn.GetComponent<AdderMoneyCount>());
            ChangerAdder(adderList.Count - 1, countMoney);
        }
    }
    
}
