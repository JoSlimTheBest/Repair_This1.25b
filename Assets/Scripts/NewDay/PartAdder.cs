using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PartAdder : MonoBehaviour
{
    public AllStatsDayEnd stats;
    public TextMeshProUGUI text;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    public GameObject rent;
    public void ChangeAdderPart(int money)
    {
        stats.ChangerAdder(2, money);
        text.text = money.ToString();
    }

    public void ChangeAdderDelivery(int money)
    {
        stats.ChangerAdder(3, money);
        text2.text = money.ToString();
    }

    public void ChangeRentAdder(int Money)
    {
        if(Money < 0)
        {
            
            rent.SetActive(true);
            stats.ChangerAdder(4, Money);
            text3.text = Money.ToString();
        }
        else
        {
            rent.SetActive(false);
            text3.text = Money.ToString();
        }

    }
}
