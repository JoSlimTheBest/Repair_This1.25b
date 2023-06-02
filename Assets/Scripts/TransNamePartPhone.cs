using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleLocalizator;

public class TransNamePartPhone : MonoBehaviour
{
    public List<string> partNameRus = new List<string>();
    public List<string> partNameEng = new List<string>();


    public GameObject costChanger;
    public GameObject stockPart;
    public int phoneIndex = 1732;
    public void Start()
    {
        partNameEng.Add("Display");
        partNameEng.Add("Camera");
        partNameEng.Add("Bottom Board");
        partNameEng.Add("Main board");
        partNameEng.Add("Dinamic");
        partNameEng.Add("Back Panel");


        partNameRus.Add("Дисплей");
        partNameRus.Add("Камера");
        partNameRus.Add("Нижняя плата");
        partNameRus.Add("Основная плата");
        partNameRus.Add("Динамик");
        partNameRus.Add("Задняя панель");


    }
    public string GetName(int numb)
    {
        string name;
        if(LanguageManager.currentLang == Language.English)
        {
            name = partNameEng[numb];
        }
        else
        {
            name = partNameRus[numb];
        }
       
        return name;
    }
}
