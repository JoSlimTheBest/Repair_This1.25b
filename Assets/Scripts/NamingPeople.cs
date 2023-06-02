using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NamingPeople : MonoBehaviour
{
    public List<string> nameEngMan = new List<string>();
    public List<string> nameEngWoMan = new List<string>();
    public List<string> nameRusMan = new List<string>();
    public List<string> nameRusWoMan = new List<string>();
    public List<string> surnameEng = new List<string>();
    public List<string> surnameRus = new List<string>();

    public void Start()
    {

        TextAsset txt = (TextAsset)Resources.Load("HumanName\\ManEng\\ManEng", typeof(TextAsset));
        nameEngMan = new List<string>(txt.text.Split('\n'));


        TextAsset txt2 = (TextAsset)Resources.Load("HumanName\\WomanEng\\WomanEng", typeof(TextAsset));
        nameEngWoMan = new List<string>(txt2.text.Split('\n'));

        TextAsset txt3 = (TextAsset)Resources.Load("HumanName\\ManRus\\ManRus", typeof(TextAsset));
        nameRusMan = new List<string>(txt3.text.Split('\n'));

        TextAsset txt4 = (TextAsset)Resources.Load("HumanName\\WomanRus\\WomanRus", typeof(TextAsset));
        nameRusWoMan = new List<string>(txt4.text.Split('\n'));

        TextAsset txt5 = (TextAsset)Resources.Load("HumanName\\SurnameEng\\SurnameEng", typeof(TextAsset));
        surnameEng = new List<string>(txt5.text.Split('\n'));

        TextAsset txt6 = (TextAsset)Resources.Load("HumanName\\SurnameRus\\SurnameRus", typeof(TextAsset));
        surnameRus = new List<string>(txt6.text.Split('\n'));

       

    }


    public string GiveName(bool man,bool eng)
    {
        string n;
        string s;
        if(man == true)
        {
            if(eng == true)
            {
                n = nameEngMan[ Random.Range(0, nameEngMan.Count)];
                s = surnameEng[Random.Range(0, surnameEng.Count)];
            }
            else
            {
                n = nameRusMan[Random.Range(0, nameRusMan.Count)];
                s = surnameRus[Random.Range(0, surnameRus.Count)];
            }
        }
        else
        {
            if (eng == true)
            {
                n = nameEngWoMan[Random.Range(0, nameEngWoMan.Count)];
                s = surnameEng[Random.Range(0, surnameEng.Count)];
            }
            else
            {
                n = nameRusWoMan[Random.Range(0, nameRusWoMan.Count)];
                s = surnameRus[Random.Range(0, surnameRus.Count)];
            }
        }
        // string ret = n;
      
        string ret = n;
       
        return ret;
    }
}
