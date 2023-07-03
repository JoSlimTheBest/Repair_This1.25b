using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCharacter : MonoBehaviour
{
    public int money = 0;
    public float raiting = 1;
    public int countPeopleRaitingVoice=1;
    public float allRaiting = 1;
    public RewiewHolder holderR;
    public GameObject moneyChoiceInterf;
    public int choiceMoneyAdd;
    public int tax = 10;

    public DoorController door;


    public GameObject moneyOnScreen;
    public GameObject safebox;
    public GameObject cashbox;
    public bool creditTake = false;

    public void Start()
    {
        GivePeopleDay();
    }

    public void AddRaiting(int rait, string currentRewiew,Sprite human)
    {
        allRaiting += rait;
        countPeopleRaitingVoice += 1;
        raiting = allRaiting / countPeopleRaitingVoice;


        holderR.AddRewiew(rait, currentRewiew,human);
    }

   

    public bool AddMoney(int countMoney)
    {
        if(money + countMoney>= 0)
        {
            money += countMoney;
            return true;
        }
        else
        {
            return false;
        }
         
    }

    public void MoneyChoiceTaker(int moneyCurrentAdd)
    {
        choiceMoneyAdd = moneyCurrentAdd;
        moneyChoiceInterf.SetActive(true);
        moneyChoiceInterf.GetComponent<LandLordPassive>().CheckPossibility();
    }

    

    public void TaxMoney()
    {
        AddMoney(choiceMoneyAdd);
        GameObject flyM =  Instantiate(moneyOnScreen, cashbox.transform);
        flyM.transform.position += new Vector3(0, 0, 0);
        flyM.GetComponent<TextMeshPro>().text = "+" + choiceMoneyAdd.ToString() + "$";
        AddMoney(-choiceMoneyAdd / tax);
        GameObject flyM2 = Instantiate(moneyOnScreen, cashbox.transform);
        flyM2.transform.position += new Vector3(2, 0, 0);
        flyM2.GetComponent<TextMeshPro>().color = new Color(1, 0.5f, 0.5f, 1);
        flyM2.GetComponent<TextMeshPro>().text =(-choiceMoneyAdd / tax).ToString() + "$"; ;
        GameObject.Find("QueueControll").GetComponent<HumanQueue>().HumanExit();
        GameObject.Find("BoxButton").GetComponent<BoxOffice>().dayMoney += choiceMoneyAdd;
    }
    public void NoTaxMoney()
    {
        AddMoney(choiceMoneyAdd);
        HumanQueue queue = GameObject.Find("QueueControll").GetComponent<HumanQueue>();
        if(queue.humanList[0].GetComponent<CallCops>() != null)
        {
            queue.humanList[0].GetComponent<CallCops>().Prison();
            return;
        }
        else
        {
            queue.HumanExit();
        }
        
        GameObject flyM = Instantiate(moneyOnScreen, safebox.transform);

        safebox.GetComponent<SafeBoxHoldMoney>().AddMoneySafe(choiceMoneyAdd);
        flyM.transform.position += new Vector3(0, 0, 0);
        flyM.GetComponent<TextMeshPro>().text = "+" + choiceMoneyAdd.ToString() + "$"; ;
    }


    public void GivePeopleDay()
    {
        if(raiting <= 1)
        {
            for(int i =0; i < 3; i++)
            {
                door.HumanInsta();
            }
           
        }
        else
        {
            int countP = Mathf.RoundToInt((float)(raiting * 1.7));
            Debug.Log("human eq " + countP);
            for (int i= 0; i < countP; i++)
            {
                door.HumanInsta();
            }
        }
        if(door.prefabTrash.Count > 0)
        {
            int randomTrash = Random.Range(0, door.prefabTrash.Count);
            door.HumanInsta(door.prefabTrash[randomTrash]);
            door.prefabTrash.Remove(door.prefabTrash[randomTrash]);
        }
        
       
    }
}
