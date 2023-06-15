using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeBoxHoldMoney : MonoBehaviour
{
    public int dayMoney = 0;


    public void AddMoneySafe(int money)
    {
        dayMoney += money;
    }
}
