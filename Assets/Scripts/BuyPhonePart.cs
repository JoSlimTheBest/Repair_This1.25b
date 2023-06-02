using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyPhonePart : MonoBehaviour
{
    public List<GameObject> part = new List<GameObject>();
    public List<int> costEasyBuy = new List<int>();

    public List<Sprite> spritePart = new List<Sprite>();
    public string model;

    public int countPart = 6;
    public GameObject prEasyBuyButton;
    public GameObject prLightningBuyButton;
    public GameObject deliveryButton;


    public int spaceForEasyButton;
    public int spaceLightButton;


    public int priceDisplay;
    public int priceCamera;
    public int priceBottomBoard;
    public int priceMainBoard;
    public int priceDinamic;
    public int priceBackPanel;

    public int deliveringPrice;
    public void Awake()
    {
        costEasyBuy.Add(priceDisplay);
        costEasyBuy.Add(priceCamera);
        costEasyBuy.Add(priceBottomBoard);
        costEasyBuy.Add(priceMainBoard);
        costEasyBuy.Add(priceDinamic);
        costEasyBuy.Add(priceBackPanel);


        for (int i = 0; i < countPart; i++)
        {
            GameObject _part = Instantiate(prEasyBuyButton, transform);
            _part.transform.localPosition = new Vector3( 250 * (i ), spaceForEasyButton);
            _part.GetComponent<EasyBuyButton>()._price = costEasyBuy[i];
            _part.GetComponent<EasyBuyButton>()._partPhone = i;
            _part.GetComponent<EasyBuyButton>()._model = model;
            _part.GetComponent<EasyBuyButton>().choiseDelivery = deliveryButton;
            _part.GetComponent<EasyBuyButton>().imagePart.sprite = spritePart[i];
            part.Add(_part);
           
        }



        /*
        for (int i = 0; i < countPart; i++)
        {
            GameObject _part = Instantiate(prLightningBuyButton, transform);
            _part.transform.localPosition = new Vector3(spaceLightButton, -100 * (i + 1));
            _part.GetComponent<LightningBuyButton>()._price = buttonEasyBuy[i] +deliveringPrice;
            _part.GetComponent<LightningBuyButton>()._partPhone = i;
            _part.GetComponent<LightningBuyButton>()._model = model;
            part.Add(i);

        }
        */
    }


    public void CheckName()
    {
        for(int i = 0; i<part.Count; i++)
        {
            part[i].GetComponent<EasyBuyButton>().Naming();
        }
    }
   
}
