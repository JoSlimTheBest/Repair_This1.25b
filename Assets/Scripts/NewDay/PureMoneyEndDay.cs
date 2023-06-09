using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PureMoneyEndDay : MonoBehaviour
{
    public int MoneyAdd = 0;
    public List<AdderMoneyCount> moneyMinus = new List<AdderMoneyCount>();
    private TextMeshProUGUI text;

    public GameObject endDay;

    public AllStatsDayEnd stats;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void MoneyOnScreen()
    {
        moneyMinus = stats.adderList;
        MoneyAdd = 0;
        for (int i = 0; i < moneyMinus.Count; i++)
        {
            MoneyAdd += moneyMinus[i].currentMoney;
        }

        if(MoneyAdd<= 0)
        {
            text.text =MoneyAdd.ToString();
            text.color = new Color(1, 0, 0);
        }
        else
        {

            text.text ="+" +MoneyAdd.ToString();
            text.color = new Color(0, 1, 0);
        }
        
        endDay.SetActive(true);
    }
}
