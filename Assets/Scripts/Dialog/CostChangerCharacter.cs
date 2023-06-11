using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SimpleLocalizator;

public class CostChangerCharacter : MonoBehaviour
{
    

    public TextMeshProUGUI mainDiscription;
    public BuyPhonePart modelPhoneCostTaker;
    public StockPhonePart stockPartTaker;
    public int cost;
    public TransNamePartPhone plTranslate;

    public GameObject _costRepairHolder;


    public BuyPhonePart A;
    public BuyPhonePart M;
    public BuyPhonePart S;
    public StockPhonePart stockA;
    public StockPhonePart stockM;
    public StockPhonePart stockS;


    public GameObject buttonOnScreenMin;
    public GameObject buttonOnScreenMid;
    public GameObject buttonOnScreenMax;
    public GameObject timeColorSaver;

    public TextMeshProUGUI sparePartText;

    public int plusMoneyMin = 100;
    public int plusMoneyMid = 150;
    public int plusMoneyMax = 200;

    public int realCostStatus = 0;
    public int realTimeStatus = 0;
    public GameObject agreeButton;

    public Sprite notWork;
    public Sprite workNow;

    public Image brokenPartImage;
    public Image phoneScreen;


    public TextMeshProUGUI namePart;

   public List<Sprite> spritePhone = new List<Sprite>();

    private bool partHAVE = false;
    private float colorWait = 1;

    public Color greeen;
    public Color reeed;

    private bool openHelp;
    public GameObject helpOpen;
    private void Awake()
    {
        plTranslate = GameObject.Find("Player").GetComponent<TransNamePartPhone>();
       
    }
    private void LookHelp()
    {
        helpOpen.SetActive(true);
        openHelp = true;
    }
    public void Changer(int brokenPartPhone,string modelPhone)
    {
        if(openHelp == false)
        {
            Invoke("LookHelp", 1f);


        }
        agreeButton.GetComponent<Button>().enabled = false;
        agreeButton.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        agreeButton.GetComponent<Image>().sprite = notWork;
        realCostStatus = 0;
        realTimeStatus = 0;

        if(modelPhone == "A")
        {
            modelPhoneCostTaker = A;
            stockPartTaker = stockA;
            brokenPartImage.sprite = A.spritePart[brokenPartPhone];
            phoneScreen.sprite = spritePhone[0];
        }

        if(modelPhone == "M")
        {

            modelPhoneCostTaker =  M;
            stockPartTaker = stockM;
            brokenPartImage.sprite = M.spritePart[brokenPartPhone];
            phoneScreen.sprite = spritePhone[1];
        }

        if(modelPhone == "S")
        {
            modelPhoneCostTaker = S;
            stockPartTaker = stockS;
            brokenPartImage.sprite = S.spritePart[brokenPartPhone];
            phoneScreen.sprite = spritePhone[2];
        }

        

        if(LanguageManager.currentLang == Language.English)
        {
            mainDiscription.text = "model " + modelPhone ;
        }
        else
        {
            mainDiscription.text = "модель " + modelPhone;
        }

        Debug.Log(modelPhoneCostTaker + " " + brokenPartPhone);
        cost = modelPhoneCostTaker.costEasyBuy[brokenPartPhone];

        buttonOnScreenMin.GetComponent<SetCostPlayer>().GetCost(cost + plusMoneyMin, gameObject.GetComponent<CostChangerCharacter>());
        buttonOnScreenMid.GetComponent<SetCostPlayer>().GetCost(cost + plusMoneyMid, gameObject.GetComponent<CostChangerCharacter>());
        buttonOnScreenMax.GetComponent<SetCostPlayer>().GetCost(cost + plusMoneyMax, gameObject.GetComponent<CostChangerCharacter>());

        buttonOnScreenMin.GetComponent<MoneyButtonChangerColor>().AllColorDisable();
        timeColorSaver.GetComponent<MoneyButtonChangerColor>().AllColorDisable();




        if (LanguageManager.currentLang == Language.English)
        {
            namePart.text = plTranslate.partNameEng[brokenPartPhone];
            sparePartText.text =   "spare part in stock " +stockPartTaker.partCount[brokenPartPhone].ToString();
            if (stockPartTaker.partCount[brokenPartPhone] > 0)
            {
                sparePartText.color = reeed;
                partHAVE = true;
            }
            else
            {
                sparePartText.color = greeen;
                partHAVE = false;
            }
            
        }
        else
        {

            namePart.text = plTranslate.partNameRus[brokenPartPhone];
            sparePartText.text = "запчастей в наличии " + stockPartTaker.partCount[brokenPartPhone].ToString();

            if (stockPartTaker.partCount[brokenPartPhone] > 0)
            {
                sparePartText.color = reeed;
                partHAVE = true;
            }
            else
            {
                sparePartText.color = greeen;
                partHAVE = false;
            }
        }

    }

    public void SetTime(int timing)
    {
        realTimeStatus = timing;
        Check();
    }

    public void SetCost(int costButton)
    {
        realCostStatus = costButton;
        Check();
    }
     
    public void Check()
    {
        if(realTimeStatus !=0 && realCostStatus != 0)
        {

            agreeButton.GetComponent<Button>().enabled = true;
            agreeButton.GetComponent<Image>().color = new Color(0, 1, 0, 1);
            agreeButton.GetComponent<Image>().sprite = workNow;
            agreeButton.GetComponent<ApprovePhone>().AgreePhone(realCostStatus, realTimeStatus);
        }
    }


    public void FixedUpdate()
    {
        if (partHAVE == true && colorWait <0)
        {
            colorWait = 1;
            if(sparePartText.color == greeen)
            {
                sparePartText.color = reeed;
            }
            else
            {
                sparePartText.color = greeen;
            }
        }
        else
        {
            colorWait -= Time.deltaTime;
        }
    }

}
