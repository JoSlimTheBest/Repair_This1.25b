using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ElectricBill : MonoBehaviour
{
    public float moneyBillCurrentDay = 0;
    public int billOnScreen = 0;

    public AudioClip pay;
    public AudioClip error;
    public TextMeshProUGUI countPay;


    public void Start()
    {
        countPay.text = billOnScreen.ToString();


    }
    public void AddDollarBill(float count)
    {
        moneyBillCurrentDay += count;
    }

    public void Pay()
    {
        if(billOnScreen < GameObject.Find("Player").GetComponent<PlayerCharacter>().money && billOnScreen>0)
        {
            GameObject.Find("Player").GetComponent<PlayerCharacter>().AddMoney(-billOnScreen,true);
            GameObject.Find("AudioEvent").GetComponent<AudioSource>().PlayOneShot(pay);
            billOnScreen = 0;
            countPay.text = billOnScreen.ToString();
        }
        else
        {
            GameObject.Find("AudioEvent").GetComponent<AudioSource>().PlayOneShot(error);

        }
        
    }

    public void EndDay()
    {
        billOnScreen += (int)moneyBillCurrentDay;
        countPay.text = billOnScreen.ToString();
        moneyBillCurrentDay = 0;

    }
}
