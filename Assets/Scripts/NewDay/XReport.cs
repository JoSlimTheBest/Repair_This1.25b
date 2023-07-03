using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SimpleLocalizator;

public class XReport : MonoBehaviour
{

    public TextMeshProUGUI text;

    private int currentMoney;
    private int tax;
    public bool taxM = false;
    public AllStatsDayEnd stats;

    public SBoxAdderOpen sbOpen;
    public void CheckDay()
    {
        ComputerTime cT = GameObject.Find("QueueControll").GetComponent<ComputerTime>();
        currentMoney = GameObject.Find("BoxButton").GetComponent<BoxOffice>().dayMoney;
        tax = GameObject.Find("Player").GetComponent<PlayerCharacter>().tax;
        int day = cT.currentDay;
        string time = cT.hours.ToString() + ":" + cT.minute.ToString("0");
        string lineD = "----------------------";
        if (LanguageManager.currentLang == Language.English)
        {
            text.text = "X-report" + "\n" + "Day" + day.ToString() + "\n" + "Time" + time + "\n" + lineD + "\n" + "Received " + currentMoney.ToString() + "\n" + lineD + "\n" + "Taxes " + (currentMoney / tax).ToString() + "\n" + lineD + "\n" +"Enterprise Profit " + (currentMoney - (currentMoney / tax)).ToString() + "\n" + lineD + "\n";
        }
        else
        {
            text.text = "X-report" + "\n" + "Day" + day.ToString() + "\n" + "Время" + time + "\n" + lineD + "\n" + "Получено " + currentMoney.ToString() + "\n" + lineD + "\n" + "Налоги " + (currentMoney / tax).ToString() + "\n" + lineD + "\n" + "Прибыль предприятия " + (currentMoney - (currentMoney / tax)).ToString() + "\n" + lineD + "\n";
        }
       


        Invoke("AdderOpen", 2f);

       
    }


    public void AdderOpen()
    {
        stats.gameObject.SetActive(true);
        stats.ChangerAdder(0, currentMoney);
        stats.ChangerAdder(1, -currentMoney / tax);

        
        if (currentMoney == 0)
        {
            taxM = true;
        }
        else
        {
            taxM = false;
        }

        Invoke("SafeBoxOpen", 2f);
    }


    public void SafeBoxOpen()
    {
        sbOpen.gameObject.SetActive(true);
        sbOpen.OpenSafeCheckMoney();
    }
}
