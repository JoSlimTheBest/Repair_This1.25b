using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleLocalizator;

public class LearnMiddleTime : MonoBehaviour
{


    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(Task);

    }

    public void Task()
    {
        if(LanguageManager.currentLang == Language.English)
        {
            GameObject.Find("HelperDevice").GetComponent<LariseHelper>().SayHelp("According to statistics, the majority agrees to 3 hours");
        }
        else
        {
            GameObject.Find("HelperDevice").GetComponent<LariseHelper>().SayHelp("ѕо статистике большинство соглашаетс€ на 3 часа");
        }
        
    }
}
