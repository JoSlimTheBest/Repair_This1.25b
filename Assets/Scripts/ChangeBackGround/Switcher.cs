using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleLocalizator;

public class Switcher : MonoBehaviour
{
    public ChangerAlpha dirty;
    public ChangerAlpha b;

    public bool change = false;

    public Sprite ON;
    public Sprite OFF;

    [SerializeField, Range(0f, 0.7f)] public float countDirtyOFF;
    [SerializeField, Range(0f, 0.7f)] public float countLightOFF;

    [SerializeField, Range(0f, 0.7f)] public float countDirtyON;
    [SerializeField, Range(0f, 0.7f)] public float countLightON;
    AudioSource aSource;
    public AudioClip soundSwitch;

    public SpriteRenderer TV;
    public Sprite day;
    public Sprite night;
    public bool helperSay;

    public void Start()
    {
        aSource = GameObject.Find("AudioEvent").GetComponent<AudioSource>();
    }
    public void ChangerA()
    {
        if(helperSay == false)
        {
            if(LanguageManager.currentLang == Language.English)
            {
                GameObject.Find("HelperDevice").GetComponent<LariseHelper>().SayHelp("After 18:00, you should turn on the lights, otherwise customers may think that we are closed");
            }
            else
            {
                GameObject.Find("HelperDevice").GetComponent<LariseHelper>().SayHelp("¬ечером стоит включать свет, иначе клиенты могут подумать что мы закрыты");
            }
            helperSay = true;
            
        }

        if(change == false)
        {
            dirty.AlphaChanger(countDirtyON);
            b.AlphaChanger(countLightON);
            change = true;
            aSource.PlayOneShot(soundSwitch);
            GetComponent<SpriteRenderer>().sprite = ON;
            TV.sprite = day;
        }
        else
        {
            dirty.AlphaChanger(countDirtyOFF);
            b.AlphaChanger(countLightOFF);
            GetComponent<SpriteRenderer>().sprite = OFF;
            change = false;
            aSource = GameObject.Find("AudioEvent").GetComponent<AudioSource>();
            aSource.PlayOneShot(soundSwitch);
            TV.sprite = night;
        }
       
    }
}
