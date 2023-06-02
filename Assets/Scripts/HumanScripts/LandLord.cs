using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleLocalizator;
using TMPro;

public class LandLord : MonoBehaviour
{

    private MessageHolder messHold;
    public GameObject messagePrefab;
    public bool wait = false;
    public bool myTurn = false;
    public int appartmentcost= 500;


    public GameObject dialogPrefab;

    public List<string> manRus = new List<string>();
    public List<string> manEng = new List<string>();
    public List<string> womanRus = new List<string>();
    public List<string> womanEng = new List<string>();


    private bool coommentt = false;
    private float comentSec = 2;


    private void Start()
    {
       messHold = GameObject.Find("ManagerStock").GetComponent<ManagerStock>().mess;

        Invoke("GoMess", 1f);
    }

    public void GoMess()
    {
        messHold.AddMessages(messagePrefab);
    }


    public void ShutUpAndTakeMoney()
    {
        GameObject.Find("QueueControll").GetComponent<HumanQueue>().block2place = false;
        GameObject.Find("QueueControll").GetComponent<HumanQueue>().ChangeLock(true);
        GetComponent<Animator>().SetBool("Deliver", true);
        GetComponent<Animator>().SetBool("ExitTime", true);

        Destroy(gameObject, 1f);
    }


    public void FixedUpdate()
    {
        if(wait == true)
        {
            GameObject.Find("QueueControll").GetComponent<HumanQueue>().HumanEventList(gameObject);
        }
        

        if(coommentt == true)
        {
            comentSec -= Time.deltaTime;
            if(comentSec < 0)
            {
                coommentt = false;
                comentSec = 2;
            }
        }
    }


    public void Comment(HumanCharacter human)
    {
        if(coommentt == true || human.GetComponent<FirstDialog>().readySpeak == true)
        {
            return;
        }

        GameObject currentDialog = Instantiate(dialogPrefab, transform.position, transform.rotation, transform);
        currentDialog.transform.localPosition += new Vector3(-3f, 1.5f);
        currentDialog.GetComponent<SpriteRenderer>().flipX = true;
        currentDialog.transform.Rotate(0, 0, Random.Range(-2, 3));
        Destroy(currentDialog, 6);

        if(human.man == true)
        {
            if (LanguageManager.currentLang == Language.English)
            {
                currentDialog.GetComponentInChildren<Transform>().GetComponentInChildren<TextMeshPro>().text = manEng[Random.Range(0, manEng.Count)];
            }
            else
            {
                currentDialog.GetComponentInChildren<Transform>().GetComponentInChildren<TextMeshPro>().text = manRus[Random.Range(0, manRus.Count)];
            }
        }
        else
        {
            if (LanguageManager.currentLang == Language.English)
            {
                currentDialog.GetComponentInChildren<Transform>().GetComponentInChildren<TextMeshPro>().text = womanEng[Random.Range(0, womanEng.Count)];
            }
            else
            {
                currentDialog.GetComponentInChildren<Transform>().GetComponentInChildren<TextMeshPro>().text = womanRus[Random.Range(0, womanRus.Count)];
            }
        }
        coommentt = true;
       
    }

}
