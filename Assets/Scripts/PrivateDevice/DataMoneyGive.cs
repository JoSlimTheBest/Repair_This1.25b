using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class DataMoneyGive : MonoBehaviour
{
    public int money;
    public GameObject mess;
    public MessageHolder holder;
    public GameObject newMessage;

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
    }
}
