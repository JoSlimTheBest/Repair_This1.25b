using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class DataMoneyGive : MonoBehaviour
{
    public int money;
    public GameObject mess;
    public MessageHolder holder;
    public GameObject newMessage;

    public GameObject prefabMoney;
    public GameObject moneyPlace;

    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(Task);
    }

    public void Task()
    {
        GameObject.Find("Player").GetComponent<PlayerCharacter>().AddMoney(money);
        holder.AddMessages(newMessage);
        holder.DestroyMessage(mess);
       

        gameObject.SetActive(false);


        GameObject pref = Instantiate(prefabMoney, moneyPlace.transform);
        pref.transform.localPosition += new Vector3(0, 100, 0);
        pref.GetComponent<TextMeshProUGUI>().text = "+"+money.ToString();
        pref.GetComponent<TextMeshProUGUI>().color = Color.green;
    }
}
