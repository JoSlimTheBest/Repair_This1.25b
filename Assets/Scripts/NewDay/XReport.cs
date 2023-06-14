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
            text.text = "X-report" + "\n" + "Day" + day.ToString() + "\n" + "Time" + time + "\n" + lineD + "\n" + "Received " + currentMoney.ToString() + "\n" + lineD + "\n" + "Taxes " + (currentMoney / tax).ToString() + "\n" + lineD + "\n" +"Net Profit " + (currentMoney - (currentMoney / tax)).ToString() + "\n" + lineD + "\n";
        }
        else
        {
            text.text = "X-report" + "\n" + "Day" + day.ToString() + "\n" + "Время" + time + "\n" + lineD + "\n" + "Получено " + currentMoney.ToString() + "\n" + lineD + "\n" + "Налоги " + (currentMoney / tax).ToString() + "\n" + lineD + "\n" + "Чистая Прибыль " + (currentMoney - (currentMoney / tax)).ToString() + "\n" + lineD + "\n";
        }

       
        GameObject.Find("BoxButton").GetComponent<BoxOffice>().dayMoney = 0;
        if (currentMoney == 0)
        {
            taxM = true;
        }
        else
        {
            taxM = false;
        }
    }
}
