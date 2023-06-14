using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SimpleLocalizator;

public class AlarmClock : MonoBehaviour
{
    public AudioClip alarming;
    public LariseHelper console;

    public List<string> dayEndEng;
    public List<string> dayEndRus;
     
    public void AlarmActive()
    {
        GetComponent<AudioSource>().PlayOneShot(alarming);
        GetComponent<Animator>().SetTrigger("AlarmTrigger");

        int say = Random.Range(0, dayEndEng.Count);
        if(LanguageManager.currentLang == Language.English)
        {
            console.SayHelp(dayEndEng[say]);
        }
        else
        {
            console.SayHelp(dayEndRus[say]);
        }
        
    }

  
}
