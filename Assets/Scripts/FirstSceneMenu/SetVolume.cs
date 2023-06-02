using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{

    public AudioMixer mixer;
    private bool silenceActive = false;
    private float current;

    public Image imageSilnce;
    public Sprite silence;
    public Sprite noS;

    public void Start()
    {
        SetLevel(GetComponent<Slider>().value);
    }
    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue)*20);

        if(sliderValue > 0.0001f)
        {
            silenceActive = false;
        }
        else
        {
            silenceActive = true;
        }
        CheckImage();
    }


    public void SetSilence()
    {
        if(silenceActive == false)
        {
            current = GetComponent<Slider>().value;
            GetComponent<Slider>().value = 0.0001f;
            silenceActive = true;
        }
        else
        {
            GetComponent<Slider>().value = current;
            silenceActive = false;
        }

        CheckImage();
    }

    public void CheckImage()
    {
        if(silenceActive == true)
        {
            imageSilnce.sprite = silence;

        }
        else
        {
            imageSilnce.sprite = noS;
        }
    }
}
