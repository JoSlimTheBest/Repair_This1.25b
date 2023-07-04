using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LightningBuyButton : MonoBehaviour
{
    public int _partPhone;
    public int _price;

    public string _model;

    private PlayerCharacter player;
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(Buy);
        player = GameObject.Find("Player").GetComponent<PlayerCharacter>();
        GetComponentInChildren<TextMeshProUGUI>().text = _price.ToString();
    }

    private void Buy()
    {
        if (player.AddMoney(-_price,true,-1) == true)
        {
            player.AddMoney(-_price,true,-1);
        }
        else
        {
            //AddError
        }
    }
}
