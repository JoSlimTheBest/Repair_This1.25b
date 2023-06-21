using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SimpleLocalizator;

public class CallCops : MonoBehaviour
{
    public GameObject cop;
    public GameObject dialogprefab;
    public GameObject dialogChanger;

    public string sayEnglish;
    public string sayRussian = "Вот ты и попался! Я из налоговой!";
    public void Prison()
    {

        Invoke("SayIt", 2f);

        

    }

   
    public void SayIt()
    {
        Instantiate(cop);
        GameObject.Find("Player").GetComponent<PlayerStatistic>().EndGame(2);
        GameObject currentDialog = Instantiate(dialogprefab, transform.position, transform.rotation, dialogChanger.transform);
        currentDialog.transform.localPosition += new Vector3(-3.5f, 0.3f);
        currentDialog.transform.Rotate(0, 0, Random.Range(-2, 3));
        Destroy(currentDialog, 5);
        if (LanguageManager.currentLang == Language.English)
        {
            currentDialog.GetComponentInChildren<Transform>().GetComponentInChildren<TextMeshPro>().text = sayEnglish;
        }
        else
        {
            currentDialog.GetComponentInChildren<Transform>().GetComponentInChildren<TextMeshPro>().text = sayRussian;
        }

    }
}
