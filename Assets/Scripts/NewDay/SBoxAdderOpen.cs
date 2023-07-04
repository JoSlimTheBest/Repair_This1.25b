using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SBoxAdderOpen : MonoBehaviour
{
    public SafeBoxHoldMoney moneyHolder;
    public AllStatsDayEnd stats;
    public TextMeshProUGUI textSafe;

    public PureMoneyEndDay pure;
    public AudioClip sound;
    public AudioClip sound2;

    public GameObject partImage;

    public Sprite safe1;
    public Sprite safe2;
    public Sprite safe3;
    public void OpenSafeCheckMoney()
    {
        GetComponent<Image>().sprite = safe1;
        
        stats.ChangerAdder(0, moneyHolder.dayMoney);
        GameObject.Find("AudioEvent").GetComponent<AudioSource>().PlayOneShot(sound);
        textSafe.text = moneyHolder.dayMoney.ToString();

        if (moneyHolder.dayMoney > 0)
        {
            Invoke("OpenHalf", 0.3f);

        }
        Invoke("OpenPartImage", 2f);
    }
    private void OpenHalf()
    {
        GetComponent<Image>().sprite = safe2;
        Invoke("OpenFull", 0.3f);
    }
    private void OpenFull()
    {
        GetComponent<Image>().sprite = safe3;
        
    }


    public void OpenPartImage()
    {
        partImage.SetActive(true);
        GameObject.Find("AudioEvent").GetComponent<AudioSource>().PlayOneShot(sound);
        partImage.GetComponent<PartAdder>().stats = stats;
        partImage.GetComponent<PartAdder>().ChangeAdderPart(moneyHolder.partMoneyDay);
        partImage.GetComponent<PartAdder>().ChangeAdderDelivery(moneyHolder.partDeliveryDay);
        partImage.GetComponent<PartAdder>().ChangeRentAdder(moneyHolder.rentDay);
        Invoke("FinalCheck", 2f);
    }

    public void FinalCheck()    
    {
        GameObject.Find("AudioEvent").GetComponent<AudioSource>().PlayOneShot(sound2);
        pure.gameObject.SetActive(true);
        pure.MoneyOnScreen();
    }
}
