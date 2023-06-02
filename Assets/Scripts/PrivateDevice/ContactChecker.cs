using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleLocalizator;
using TMPro;


public class ContactChecker : MonoBehaviour
{
    public string rusName;
    public string engName;

    public string numberContact;

    public TMP_FontAsset invert;
    public TMP_FontAsset usual;
    private NamingPeople namingP;

    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(Task);

        namingP = GameObject.Find("ManagerStock").GetComponent<NamingPeople>();

        int random = Random.Range(0, 2);
        bool man;
        if (random > 0)
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
        if (numberContact == "0")
        {
            numberContact = "+7981" + Random.Range(1000000, 9999999);

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
       

        GetComponentInParent<PrivateScreen3>().CloseAll();
        GetComponentInParent<PrivateScreen3>().OpenDiscription(numberContact, null);

        GameObject parent = GetComponentInParent<PrivateScreen3>().gameObject;

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
