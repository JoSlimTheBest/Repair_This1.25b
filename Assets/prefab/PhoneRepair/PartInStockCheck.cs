using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PartInStockCheck : MonoBehaviour
{
    //private ManagerStock manager;
    public StockPhonePart part;
    public int numberPhone;
    public int numberPart;
    public TextMeshProUGUI text;
    /*
    public void Start()
    {
        manager = GameObject.Find("ManagerStock").GetComponent<ManagerStock>();
        text = GetComponent<TextMeshProUGUI>();

        if(numberPhone == 0)
        {
            part = manager.modelA;
        }

        if(numberPhone == 1)
        {
            part = manager.modelM;
        }

        if(numberPhone == 2)
        {
            part = manager.modelS;
        }
    }
    */


    public void CheckPart()
    {
        
        
        text.text = part.partCount[numberPart].ToString(); 
        if(part.partCount[numberPart] > 0)
        {
            text.color = new Color(0.5f, 0.1f, 0.03f);
           

        }
        else
        {
            text.color = Color.black;
        }
    }
}
