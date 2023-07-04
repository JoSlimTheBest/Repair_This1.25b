using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MedalCheck : MonoBehaviour
{
    public string naming;
    public Sprite current;
    public int countMoney;
    public Image imgInit;
    public TextMeshProUGUI text;
    public AllStatsDayEnd stats;
    public HolderMoneyDay hmd;

    public float ofsetX;
    public float ofsetY;

    public void Start()
    {
        if(countMoney > 0)
        {
            text.color = new Color(0, 0, 1);
            text.text = "+" + countMoney;
        }
        else
        {
            text.text = countMoney.ToString();
            text.color = Color.red;
        }

        imgInit.sprite = current;

        ChangeNumbers();
    }

    public void ChangeNumbers()
    {
        stats.InstAdder(naming, naming, countMoney);
        Invoke("NextM", 3f);
    }

    public void NextM()
    {
        gameObject.transform.localPosition = new Vector3(ofsetX, ofsetY);
        hmd.CheckLists();
    }
        
}
