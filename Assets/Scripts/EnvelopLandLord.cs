using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SimpleLocalizator;
using UnityEngine.SceneManagement;

public class EnvelopLandLord : MonoBehaviour
{
    public GameObject llord;
    public GameObject open;
    public int billPay;


    public GameObject dialogprefab;
    public bool saySome;
    private float shutUp = 4;

    private ComputerTime time;
    private bool checkTime;
    void Start()
    {
        time = GameObject.Find("QueueControll").GetComponent<ComputerTime>();
        billPay = llord.GetComponent<LandLord>().appartmentcost;
        open.SetActive(false);
    }

    public void OpenEnvelope()
    {
        open.SetActive(true);
    }


    public void Pay()
    {
        PlayerCharacter pl = GameObject.Find("Player").GetComponent<PlayerCharacter>();
       if (pl.money >= billPay)
       {
            pl.money -= billPay;
            llord.GetComponent<LandLord>().ShutUpAndTakeMoney();

            GameObject currentDialog = Instantiate(dialogprefab, llord.transform.position, llord.transform.rotation, transform);
            currentDialog.transform.localPosition += new Vector3(-3f, 1.5f);
            currentDialog.GetComponent<SpriteRenderer>().flipX = true;
            currentDialog.transform.Rotate(0, 0, Random.Range(-2, 3));
            Destroy(currentDialog, 6);
            
            if (LanguageManager.currentLang == Language.English)
            {
                currentDialog.GetComponentInChildren<Transform>().GetComponentInChildren<TextMeshPro>().text = "Nice! Have a good day!";
            }
            else
            {
                currentDialog.GetComponentInChildren<Transform>().GetComponentInChildren<TextMeshPro>().text = "Отлично, удачной работы!";
            }

            open.SetActive(false);
            Destroy(gameObject, 1f);
       }
        else
        {
            if(saySome == true) { return; }
            GameObject currentDialog = Instantiate(dialogprefab, llord.transform.position, llord.transform.rotation, transform);
            currentDialog.transform.localPosition += new Vector3(-3f, 0.3f);
            currentDialog.GetComponent<SpriteRenderer>().flipX = true;
            currentDialog.transform.Rotate(0, 0, Random.Range(-2, 3));
            Destroy(currentDialog, 4);
            if (LanguageManager.currentLang == Language.English)
            {
                currentDialog.GetComponentInChildren<Transform>().GetComponentInChildren<TextMeshPro>().text = "Not enough money?";
            }
            else
            {
                currentDialog.GetComponentInChildren<Transform>().GetComponentInChildren<TextMeshPro>().text = "Денег не хватает что-ли?";
            }
            saySome = true;
        }
        
       
    }
    private void LoseGame()
    {

        GameObject.Find("Player").GetComponent<PlayerStatistic>().EndGame(1);
        SceneManager.LoadScene(3);
    }


    public void NoMoney()
    {

        if(time.hours >= 22)
        {

            AngryLord();
            Invoke("LoseGame", 2.5f);

            return;
           
        }
        if(saySome == true) { return; }
        GameObject currentDialog = Instantiate(dialogprefab, llord.transform.position, llord.transform.rotation, transform);
        currentDialog.transform.localPosition += new Vector3(-3f, 0.3f);
        currentDialog.GetComponent<SpriteRenderer>().flipX = true;
        currentDialog.transform.Rotate(0, 0, Random.Range(-2, 3));
        Destroy(currentDialog, 4);
        if (LanguageManager.currentLang == Language.English)
        {
            currentDialog.GetComponentInChildren<Transform>().GetComponentInChildren<TextMeshPro>().text = "i can wait a bit";
        }
        else
        {
            currentDialog.GetComponentInChildren<Transform>().GetComponentInChildren<TextMeshPro>().text = "Я подожду";
        }
        saySome = true;
    }

    private void AngryLord()
    {
        GameObject currentDialog = Instantiate(dialogprefab, llord.transform.position, llord.transform.rotation, transform);
        currentDialog.transform.localPosition += new Vector3(-3f, 0.3f);
        currentDialog.GetComponent<SpriteRenderer>().flipX = true;
        currentDialog.transform.Rotate(0, 0, Random.Range(-2, 3));
        Destroy(currentDialog, 4);
        if (LanguageManager.currentLang == Language.English)
        {
            currentDialog.GetComponentInChildren<Transform>().GetComponentInChildren<TextMeshPro>().text = "i can't wait!!!";
        }
        else
        {
            currentDialog.GetComponentInChildren<Transform>().GetComponentInChildren<TextMeshPro>().text = "Ты мне надоел! Я не могу больше ждать!";
        }
    }

    private void FixedUpdate()
    {
        if (saySome == true)
        {
            shutUp -= Time.deltaTime;
            if(shutUp < 0)
            {
                saySome = false;
                shutUp = 4;
            }
        }

        if(checkTime == false)
        {
            if(time.hours == 22)
            {
                OpenEnvelope();
                checkTime = true;
            }
        }
    }

    

}
