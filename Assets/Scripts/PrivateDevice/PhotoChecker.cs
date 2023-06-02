using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleLocalizator;
using TMPro;

public class PhotoChecker : MonoBehaviour
{
    public string rusName;
    public string engName;

    public string messageCurrent;

    public Sprite photoCurrent;

    public TMP_FontAsset invert;
    public TMP_FontAsset usual;

    public List<Sprite> randomPhoto = new List<Sprite>();

    public bool copyRight = false;

    public string password;
    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(Task);

        if (rusName == "0")
        {
            rusName = "img_" + Random.Range(100,999);
        }
        if (engName == "0")
        {
            engName = "img_" + Random.Range(100, 999);
        }
        if (photoCurrent == null)
        {


            photoCurrent = randomPhoto[Random.Range(0, randomPhoto.Count)];





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
        PS3.OpenDiscription(" ", photoCurrent);

        if (copyRight == true)
        {
            PS3.OpenCopy(password);
        }
        else
        {
            PS3.CloseCopy();
        }

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
