using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SimpleLocalizator;

public class BGChangeColor : MonoBehaviour
{
    public float changeColor = 0.025f;
    private Image bg;
    
    public void Awake()
    {
        bg = GetComponent<Image>();
    }
    public void BgChanger()
    {
        bg.color = new Color(bg.color.r, bg.color.g, bg.color.b, 0);

        SetDay();
    }

    private void FixedUpdate()
    {
        bg.color = new Color(bg.color.r, bg.color.g, bg.color.b,bg.color.a + changeColor);
       
    }

    public void SetDay()
    {

        if(LanguageManager.currentLang == Language.English)
        {
            GetComponentInChildren<TextMeshProUGUI>().text = "Day " + GameObject.Find("QueueControll").GetComponent<ComputerTime>().currentDay;
        }
        else
        {
            GetComponentInChildren<TextMeshProUGUI>().text = "Δενό " + GameObject.Find("QueueControll").GetComponent<ComputerTime>().currentDay;
        }
        
    }
}
