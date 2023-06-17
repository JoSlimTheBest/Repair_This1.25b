using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeBoxHoldMoney : MonoBehaviour
{
    public int dayMoney = 0;

    public int partMoneyDay = 0;

    public int partDeliveryDay = 0;


    public void ClearAll()
    {
        dayMoney = 0;
        partDeliveryDay = 0;
            partMoneyDay = 0;
    }

    public void AddMoneySafe(int money)
    {
        dayMoney += money;
    }

    public void MinusMoneyPart(int money)
    {
        partMoneyDay -= money;

    }

    public void MinusDelivery(int moneyP)
    {
        partDeliveryDay -= moneyP;
    }
}
