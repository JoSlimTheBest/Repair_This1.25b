using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BoxOfficeCloseDay : MonoBehaviour
{
    public GameObject repX;
    public GameObject bg;
    public GameObject systemError;
    public GameObject systemError2;
    public ComputerTime compT;
    public AudioClip checkOut;
    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(CloseDay);
        
    }

    public void CloseDay()
    {

        if (compT.hours < 22)
        {

            systemError.GetComponent<AutoDestroy>().DontKill();
            
            return;
        }

        if(compT.gameObject.GetComponent<HumanQueue>().block2place == true)
        {
            systemError2.GetComponent<AutoDestroy>().DontKill();
            return;
        }
        bg.SetActive(true);
        repX.SetActive(true);
        bg.GetComponent<BGChangeColor>().BgChanger();
        repX.GetComponent<XReport>().CheckDay();
        GameObject.Find("AudioEvent").GetComponent<AudioSource>().PlayOneShot(checkOut);
    }
}
