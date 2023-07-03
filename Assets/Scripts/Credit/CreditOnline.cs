using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreditOnline : MonoBehaviour
{

    public PlayerCharacter _plChar;
    public GameObject error;

    public GameObject flyMoney;
    public GameObject moneyPlace;


    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(CreditTake);
    }

    public void CreditTake()
    {
        if(_plChar.creditTake == false)
        {
            _plChar.AddMoney(500);
            _plChar.creditTake = true;

            GameObject pref = Instantiate(flyMoney, moneyPlace.transform);
            pref.transform.localPosition += new Vector3(0, 100, 0);
            pref.GetComponent<TextMeshProUGUI>().color = Color.green;
            pref.GetComponent<TextMeshProUGUI>().text = "+500";
        }
        else
        {
            error.GetComponent<AutoDestroy>().DontKill();
        }
        
    }
}
