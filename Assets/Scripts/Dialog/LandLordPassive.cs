using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandLordPassive : MonoBehaviour
{

    public GameObject safePlace;
    public GameObject safeButton;
    public float timeOutLight;

    public OutlineShaderTake safePlaceItem;

    public OutlineShaderTake cashPlaceItem;
    public void Start()
    {
        CheckPossibility();
    }

    public void CheckPossibility()
    {
        if (GameObject.Find("QueueControll").GetComponent<HumanQueue>().block2place == true)
        {
            safePlace.SetActive(false);
            cashPlaceItem.LimitTime(timeOutLight);
            safeButton.SetActive(false);
        }
        else
        {
            safePlace.SetActive(true);
            cashPlaceItem.LimitTime(timeOutLight);
            safePlaceItem.LimitTime(timeOutLight);
            safeButton.SetActive(true);
            safeButton.SetActive(true);
        }
    }
}
