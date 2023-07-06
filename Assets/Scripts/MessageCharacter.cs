using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using SimpleLocalizator;

public class MessageCharacter : MonoBehaviour
{
    public GameObject currentField;
    public GameObject buttonDelete;
    public GameObject dataGet;
    public string textRus;
    public string textEng;
    public bool boolNew = true;
    public GameObject greenNew;

    public RedCountMessages redCountM;


    private LanguageManager playerLang;

    private PasswordHolder ps;

    public string passwordMessage = "D";
    public GameObject nextMessage;
    public int moneyPlus = 0;
   

    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(Task);
        playerLang = GameObject.Find("Player").GetComponent<LanguageManager>();
        ps = GameObject.Find("ManagerStock").GetComponent<PasswordHolder>();
        if (playerLang.yes == true)
        {

        }

        
    }
    private void Task()
    {
        if(boolNew == true)
        {
            redCountM.countNewMess -= 1;
            boolNew = false;
        }
        greenNew.SetActive(false);

        currentField.GetComponentInChildren<TextMeshProUGUI>().text = textRus;

        if(passwordMessage == ps.password)
        {
            dataGet.SetActive(true);
            dataGet.GetComponent<DataMoneyGive>().money = moneyPlus;
            dataGet.GetComponent<DataMoneyGive>().mess = gameObject;
            dataGet.GetComponent<DataMoneyGive>().newMessage = nextMessage;
            if (GetComponent<KillVanessa>() != null)
            {
                GetComponent<KillVanessa>().Kill();
            }

        }
        else
        {
            dataGet.SetActive(false);
        }

        buttonDelete.SetActive(true);
        buttonDelete.GetComponent<MessageDeleteButton>().currentmess = gameObject;

       
    }

    
}
