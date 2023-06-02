using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleLocalizator;
using TMPro;

public class AnswerHumanFact : MonoBehaviour
{
    public bool denayByTime;
    public bool denayByCost;
    public bool agreed;

    private TextMeshPro text;


    public  float delay = 1f;


    private void Start()
    {
        text = GetComponent<TextMeshPro>();
        if (denayByTime == true)
        {
            if (LanguageManager.currentLang == Language.English)
            {
                text.text = "Canceled";
                text.color = new Color(1, 0, 0, 0);
            }
            else
            {
                text.text = "Отказ";
                text.color = new Color(1, 0, 0, 0);
            }
            

        }

        if (denayByCost == true)
        {
            if (LanguageManager.currentLang == Language.English)
            {
                text.text = "Canceled";
                text.color = new Color(1, 0, 0, 0);
            }
            else
            {
                text.text = "Отказ";
                text.color = new Color(1, 0, 0, 0);
            }


        }

        if (agreed == true)
        {
            if (LanguageManager.currentLang == Language.English)
            {
                text.text = "Agreed";
                text.color = new Color(0, 1, 0, 0);
            }
            else
            {
                text.text = "Принято";
                text.color = new Color(0, 1, 0, 0);
            }


        }

        Invoke("GiveColor", delay);
    }


    private void GiveColor()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
    }
}
