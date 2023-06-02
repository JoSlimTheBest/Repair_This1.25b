using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SimpleLocalizator;

public class DeliveryController : MonoBehaviour
{
    public string model;
    public int part;
    public List<string> nameDelivery = new List<string>();
    public int pricePart;
    public List<int> deliveryPrice = new List<int>();
    public List<int> deliverHourTime = new List<int>();
    public string time;

    private PlayerCharacter player;
    private TransNamePartPhone namePart;
    private int currentDelivery = 0;


    public TextMeshProUGUI finalPrice;
    public TextMeshProUGUI finalPriceLongTime;
    public TextMeshProUGUI forBuy;


    public TextMeshProUGUI richText;

    public AudioClip error;
    public AudioClip coin;
    public GameObject deliveryGuy;
    private ComputerTime compTime;

    public int priceRusDeliver = 10;
    public int priceOneHourDeliver = 50;

    public Image spritePartPhone;
    public Image spriteMobile;

    public Sprite A;
    public Sprite M;
    public Sprite S;


    public Image buttonLong;
    public Image buttonFast;

    public int buyHour = 1;

    public int buyCostDelivery;

    
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerCharacter>();
        namePart = player.gameObject.GetComponent<TransNamePartPhone>();
        compTime = GameObject.Find("QueueControll").GetComponent<ComputerTime>();

        nameDelivery.Add("Russian post");
        nameDelivery.Add("One Hour Delivery");

        deliveryPrice.Add(priceRusDeliver);
        deliveryPrice.Add(priceOneHourDeliver);


        deliverHourTime.Add(13);
        deliverHourTime.Add(1);

        ChangeDelivery(1);
    }

    public void DeliveryOption(string modPH,int partPH,int pricePH,Sprite imagePart)
    {
        model = modPH;

        if(model == "A")
        {
            spriteMobile.sprite = A;
        }
        if (model == "M")
        {
            spriteMobile.sprite = M;
        }
        if (model == "S")
        {
            spriteMobile.sprite = S;
        }


        part = partPH;
        pricePart = pricePH;
        spritePartPhone.sprite = imagePart;
    }

    public void ChangeDelivery(int whatchange)
    {
        if(whatchange == 0)
        {
            buttonLong.color = new Color(0.7f, 1, 0.7f, 1);
            buttonFast.color = new Color(0.7f, 0.7f, 0.7f, 1);
            buyHour = 13;
            buyCostDelivery = priceRusDeliver;

        }
        else
        {
            buttonFast.color = new Color(0.7f, 1, 0.7f, 1);
            buttonLong.color = new Color(0.7f, 0.7f, 0.7f, 1);
            buyHour = 1;
            buyCostDelivery = priceOneHourDeliver;
        }
    }


    public void Buy()
    {
        if (player.money - (pricePart + buyCostDelivery) >=0)
        {
            player.AddMoney(-(pricePart + buyCostDelivery));
            gameObject.SetActive(false);

           GameObject deliverMan =  Instantiate(deliveryGuy,compTime.transform);
           
            deliverMan.transform.localPosition = new Vector3(-100, 0, 0);
            deliverMan.GetComponent<HumanCharacter>().minute = (int)compTime.minute;
            deliverMan.GetComponent<HumanCharacter>().hour = compTime.hours + buyHour;
            deliverMan.GetComponent<HumanCharacter>().delivery = true;

            if (deliverMan.GetComponent<HumanCharacter>().hour >= 22)
            {
                deliverMan.GetComponent<HumanCharacter>().day = GameObject.Find("QueueControll").GetComponent<ComputerTime>().currentDay+1;

                deliverMan.GetComponent<HumanCharacter>().hour = 10;
            }
            else
            {
                deliverMan.GetComponent<HumanCharacter>().day = GameObject.Find("QueueControll").GetComponent<ComputerTime>().currentDay;
            }

          

            deliverMan.GetComponent<HumanCharacter>()._brokenModelPhone = model;
            deliverMan.GetComponent<HumanCharacter>()._brokenPartPhone = part;
            GameObject.Find("AudioEvent").GetComponent<AudioSource>().PlayOneShot(coin);
        }
        else
        {
            GameObject.Find("AudioEvent").GetComponent<AudioSource>().PlayOneShot(error);
            //AddError
        }
    }


   



    private void FixedUpdate()
    {
        string deliveryTimeOut;
        if (compTime.minute < 9)
        {
            deliveryTimeOut = compTime.hours + buyHour + ":" + "0" + ((int)compTime.minute).ToString("0");
        }
        else
        {
            deliveryTimeOut = compTime.hours + buyHour + ":" + compTime.minute.ToString("0");
        }

        if (compTime.hours + buyHour > 22)
        {
            if (LanguageManager.currentLang == Language.English)
            {
                deliveryTimeOut = "Next Day";
            }
            else
            {
                deliveryTimeOut = "Õ‡ ÒÎÂ‰Û˛˘ËÈ ‰ÂÌ¸";
            }

        }

        richText.text = model + "\n" + namePart.GetName(part)   + "\n" + pricePart.ToString() + "\n"  + "\n" + deliveryTimeOut;



        string order = "";
        finalPrice.text = (priceOneHourDeliver).ToString() + "$";
        finalPriceLongTime.text = (priceRusDeliver).ToString() + "$";
        if (LanguageManager.currentLang == Language.English)
        {
            order = "ORDER ";
        }
        else
        {
            order = "«¿ ¿«¿“‹ ";
        }


            forBuy.text = order +(-pricePart-buyCostDelivery).ToString()+ "$";
    }
}
