using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BoxOfficeCloseDay : MonoBehaviour
{
    public GameObject repX;
    public GameObject bg;
    public GameObject systemError;
    public ComputerTime compT;
    public AudioClip checkOut;
    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(Task);
        
    }

    public void Task()
    {

        if (compT.hours < 22)
        {

            systemError.GetComponent<AutoDestroy>().DontKill();
            return;
        }
        bg.SetActive(true);
        repX.SetActive(true);
        bg.GetComponent<BGChangeColor>().BgChanger();
        repX.GetComponent<XReport>().CheckDay();
        GameObject.Find("AudioEvent").GetComponent<AudioSource>().PlayOneShot(checkOut);
    }
}
