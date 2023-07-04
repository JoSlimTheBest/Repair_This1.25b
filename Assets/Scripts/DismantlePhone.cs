using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SimpleLocalizator;

public class DismantlePhone : MonoBehaviour
{
    public string modelPhone;
    public int price;

    public Sprite A;
    public Sprite M;
    public Sprite S;

    public int part1;
    public int part2;
    public int part3;

    private ManagerStock manager;

    public GameObject choice;
    public TextMeshProUGUI text;
    public AudioClip notEnoughMoney;
    public AudioClip buying;
    private GameObject playe;

    private HumanQueue queControll;

    public Image image;

    public GameObject prefabFlyMoney;
    public void Start()
    {
        if(modelPhone == "A")
        {
            GetComponent<SpriteRenderer>().sprite = A;
            image.sprite = A;
        }
        if(modelPhone == "M")
        {
            GetComponent<SpriteRenderer>().sprite = M;
            image.sprite = M;
        }
        if(modelPhone == "S")
        {
            GetComponent<SpriteRenderer>().sprite = S;
            image.sprite = S;
        }


        part1 = Random.Range(0, 2);
        part2 = Random.Range(2, 4);
        part3 = Random.Range(4, 6);

       manager= GameObject.Find("ManagerStock").GetComponent<ManagerStock>();
        choice.SetActive(false);
        playe = GameObject.Find("Player");
        queControll = GameObject.Find("QueueControll").GetComponent<HumanQueue>();
    }

    public void DismantlePhoneNow()
    {
        
        PlayerCharacter plMoney = GameObject.Find("Player").GetComponent<PlayerCharacter>();
        if (plMoney.money - price >= 0)
        {
            playe.GetComponent<PlayerCharacter>().AddMoney(-price,true,1);
            GameObject safebox = GameObject.Find("safebox");
            safebox.GetComponent<SafeBoxHoldMoney>().MinusMoneyPart(price);
            GameObject fly = Instantiate(prefabFlyMoney, safebox.transform);
            fly.GetComponent<TextMeshPro>().text = "-"+price.ToString();
            fly.GetComponent<TextMeshPro>().color = Color.red;
            GameObject.Find("AudioEvent").GetComponent<AudioSource>().PlayOneShot(buying);
            manager.AddPart(modelPhone, part1, 1);
            manager.AddPart(modelPhone, part2, 1);
            manager.AddPart(modelPhone, part3, 1);
            choice.SetActive(false);
            queControll.HumanExit();
            Destroy(gameObject, 0f);
        }
        else
        {
            GameObject.Find("AudioEvent").GetComponent<AudioSource>().PlayOneShot(notEnoughMoney);
        }
       

        

    }

    public void Dismiss()
    {
        choice.SetActive(false);
        queControll.HumanExitAngry();
        Destroy(gameObject, 1f);
    }

    public void UsePhone()
    {
        choice.SetActive(true);

        if(LanguageManager.currentLang == Language.English)
        {
            
            text.text = playe.GetComponent<TransNamePartPhone>().partNameEng[part1] +"\n";
            text.text += playe.GetComponent<TransNamePartPhone>().partNameEng[part2] + "\n";
            text.text += playe.GetComponent<TransNamePartPhone>().partNameEng[part3] + "\n";

            text.text += "Price " + price.ToString();
        }
        else
        {
           
            text.text = playe.GetComponent<TransNamePartPhone>().partNameRus[part1] + "\n";
            text.text += playe.GetComponent<TransNamePartPhone>().partNameRus[part2] + "\n";
            text.text += playe.GetComponent<TransNamePartPhone>().partNameRus[part3] + "\n";
            text.text += "\n"+"Цена " + price.ToString();
        }
    }
}
