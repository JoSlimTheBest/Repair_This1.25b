using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SimpleLocalizator;

public class LariseHelper : MonoBehaviour
{
    public GameObject sayPrefab;
    public List<GameObject> said = new List<GameObject>();
    public ComputerTime ct;

    private void Start()
    {
        if(ct.currentDay == 1)
        {
            Invoke("SayHello", 2f);
        }
        
    }

    private void SayHello()
    {
        if(LanguageManager.currentLang == Language.English)
        {
            SayHelp("Hello! I am Larise, the smartest speaker, I will help you in your work");
        }
        else
        {
            SayHelp("Привет! Я Лариса, самая умная колонка, буду помогать тебе в работе");
        }
    }
    public void SayHelp(string whatSay)
    {
        if (said.Count > 0)
        {
            for(int i =0; i < said.Count; i++)
            {
                if(said[i] == null)
                {
                    said.Remove(said[i]);
                }
            }

            for(int i =0; i < said.Count; i++)
            {
                if (said[i] != null)
                {
                    said[i].transform.position += new Vector3(0, 1f, 0);
                }
               
            }
        }

        GameObject buuble = Instantiate(sayPrefab,transform.position,transform.rotation,transform);
        buuble.transform.localPosition = new Vector3(-2.5f, -0.4f, 0);
        buuble.GetComponentInChildren<TextMeshPro>().text = whatSay;
        said.Add(buuble);
    }
}
