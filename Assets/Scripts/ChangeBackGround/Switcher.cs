using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void Start()
    {
        aSource = GameObject.Find("AudioEvent").GetComponent<AudioSource>();
    }
    public void ChangerA()
    {
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
