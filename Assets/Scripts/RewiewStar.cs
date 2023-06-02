using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleLocalizator;

public class RewiewStar : MonoBehaviour
{
    


    public List<string> starRUS = new List<string>();
    public List<string> starENG = new List<string>();
    

    public string GiveStar(int star)
    {
        if(LanguageManager.currentLang == Language.English)
        {
            return starENG[star - 1];
        }
        else
        {
            return starRUS[star - 1];
        }

       
    }


    

}
