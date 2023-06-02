using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EasyBuyButton : MonoBehaviour
{
    public int _partPhone;
    public int _price;

    public string _model;


    public GameObject choiseDelivery;
    public Image imagePart;

    public TextMeshProUGUI textNamePart;
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ChangeDelivery);
        
        GetComponentInChildren<TextMeshProUGUI>().text = _price.ToString();
        Invoke("Naming", 0.2f);
    }

    public void Naming()
    {
        textNamePart.text = GameObject.Find("Player").GetComponent<TransNamePartPhone>().GetName(_partPhone);
    }
    private void ChangeDelivery()
    {
        choiseDelivery.SetActive(true);
        choiseDelivery.GetComponent<DeliveryController>().DeliveryOption(_model, _partPhone, _price, imagePart.sprite);
    }
  
}
