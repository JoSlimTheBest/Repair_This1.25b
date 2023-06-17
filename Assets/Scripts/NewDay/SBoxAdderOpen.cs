using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SBoxAdderOpen : MonoBehaviour
{
    public SafeBoxHoldMoney moneyHolder;
    public AllStatsDayEnd stats;
    public TextMeshProUGUI textSafe;

    public PureMoneyEndDay pure;


    public GameObject partImage;
    public void OpenSafeCheckMoney()
    {
        stats.ChangerAdder(0, moneyHolder.dayMoney);
        textSafe.text = moneyHolder.dayMoney.ToString();
        Invoke("OpenPartImage", 2f);
    }


    public void OpenPartImage()
    {
        partImage.SetActive(true);
        partImage.GetComponent<PartAdder>().stats = stats;
        partImage.GetComponent<PartAdder>().ChangeAdderPart(moneyHolder.partMoneyDay);
        partImage.GetComponent<PartAdder>().ChangeAdderDelivery(moneyHolder.partDeliveryDay);
        Invoke("FinalCheck", 4f);
    }

    public void FinalCheck()
    {
        pure.gameObject.SetActive(true);
        pure.MoneyOnScreen(stats.adderList[0].currentMoney);
    }
}
