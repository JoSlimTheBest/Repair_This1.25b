using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleLocalizator;
using TMPro;
using System.IO;

public class MessageChecker : MonoBehaviour
{
    public string rusName;
    public string engName;

    public string messageCurrentRus;
    public string messageCurrentEng;

    public TMP_FontAsset invert;
    public TMP_FontAsset usual;

    public List<string> randomMeassgeRus = new List<string>();
    public List<string> randomMeassgeEng = new List<string>();


    public bool copyRight = false;

    public string password;

    private NamingPeople namingP;
    

    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(Task);
        namingP =  GameObject.Find("ManagerStock").GetComponent<NamingPeople>();

        int random = Random.Range(0, 2);
        bool man;
        if(random >0 )
        {
            man = true;
        }
        else
        {
            man = false;
        }
        if (rusName == "0")
        {
            rusName = namingP.GiveName(man, false);
        }
        if (engName == "0")
        {
            engName = namingP.GiveName(man, true);
        }
        if (messageCurrentRus == "0")
        {


            if (LanguageManager.currentLang == Language.English)
            {
                messageCurrentEng = randomMeassgeEng[Random.Range(0, randomMeassgeEng.Count)];
            }
            else
            {
                messageCurrentRus = randomMeassgeRus[Random.Range(0, randomMeassgeRus.Count)];
            }

            
            //messageCurrent = "Приглашаем Вас на собеседование по адресу Куйбышева 48, не забудьте принести с собой паспорт";

        }

        if (LanguageManager.currentLang == Language.English)
        {
            GetComponentInChildren<TextMeshProUGUI>().text = engName;
        }
        else
        {
            GetComponentInChildren<TextMeshProUGUI>().text = rusName;
        }
    }

    public void Task()
    {

        PrivateScreen3 PS3 = GetComponentInParent<PrivateScreen3>();
        PS3.CloseAll();
        if (LanguageManager.currentLang == Language.English)
        {
            
            PS3.OpenDiscription(messageCurrentEng, null);

          
        }
        else
        {
            GetComponentInParent<PrivateScreen3>().OpenDiscription(messageCurrentRus, null);
        }

        if (copyRight == true)
        {
            PS3.OpenCopy(password);
        }
        else
        {
            PS3.CloseCopy();
        }


        GameObject parent = PS3.gameObject;

        List<GameObject> TList = new List<GameObject>();
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            TList.Add(parent.transform.GetChild(i).gameObject);
        }

        foreach (GameObject child in TList)
        {

            child.GetComponentInChildren<TextMeshProUGUI>().font = usual;


        }
        GetComponentInChildren<TextMeshProUGUI>().font = invert;
    }
}
