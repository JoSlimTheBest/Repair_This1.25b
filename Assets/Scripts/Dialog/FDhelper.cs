using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleLocalizator;

public class FDhelper : MonoBehaviour
{
    public string RusHelp;
    public string EngHelp;

    public void HelpNow()
    {
        if(LanguageManager.currentLang == Language.English)
        {
            GameObject.Find("HelperDevice").GetComponent<LariseHelper>().SayHelp(EngHelp);
        }
        else
        {
            GameObject.Find("HelperDevice").GetComponent<LariseHelper>().SayHelp(RusHelp);
        }
       
    }
}
