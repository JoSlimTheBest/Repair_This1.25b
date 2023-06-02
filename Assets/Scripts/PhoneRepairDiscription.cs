using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SimpleLocalizator;

public class PhoneRepairDiscription : MonoBehaviour
{
    public TextMeshProUGUI idPhone;
    public TextMeshProUGUI statusPhone;
    public TextMeshProUGUI detailPh;
    public Image phImage;
    public BrokenPhone currentPh;
    public GameObject buttonAction;
    public GameObject checkPhoneFiles;
   // public Image photoOnDisplay;

    private ManagerStock stock;
    private TransNamePartPhone naming;

    private void Awake()
    {
        stock = GameObject.Find("ManagerStock").GetComponent<ManagerStock>();
        naming = GameObject.Find("Player").GetComponent<TransNamePartPhone>();
    }
    public void Init(BrokenPhone phone)
    {
        currentPh = phone;
        idPhone.text = phone.index.ToString();

        //photoOnDisplay.sprite = currentPh.humanPhotoHere;  if need add photo on table SLOT!
        if (phone.model == "A")
        {
            phImage.sprite = phone.modelA;
        }
        if (phone.model == "M")
        {
            phImage.sprite = phone.modelM;
        }
        if (phone.model == "S")
        {
            phImage.sprite = phone.modelS;
        }

        if (phone.status == false)
        {
            bool onStock = stock.CheckPart(currentPh.model,currentPh.brockenPart);
            if(onStock == true)
            {
                buttonAction.SetActive(true);
                if (LanguageManager.currentLang == Language.English)
                {
                    statusPhone.text = "Waiting Repair";
                }
                else
                {
                    statusPhone.text = "Ожидает ремонта";
                }
            }
            else
            {
                if (LanguageManager.currentLang == Language.English)
                {
                    statusPhone.text = "no required spare parts";
                }
                else
                {
                    statusPhone.text = "Запчасть отсутствует";
                }
            }
        }
        else
        {
            if(LanguageManager.currentLang == Language.English)
            {
                statusPhone.text = "Ready";

                checkPhoneFiles.SetActive(true);
                checkPhoneFiles.GetComponent<CheckFiles>().phoneCheckFiles = currentPh.gameObject;
            }
            else
            {
                statusPhone.text = "Готов";

                checkPhoneFiles.SetActive(true);
                checkPhoneFiles.GetComponent<CheckFiles>().phoneCheckFiles = currentPh.gameObject;
            }
        }


        if (LanguageManager.currentLang == Language.English)
        {
            detailPh.text = "Replace part: " + naming.partNameEng[currentPh.brockenPart] +"\n"+ "Cost: " + currentPh.moneyPaying;
        }
        else
        {
            detailPh.text = "Заменить деталь: " + naming.partNameRus[currentPh.brockenPart] + "\n" + "Цена: " + currentPh.moneyPaying;
        }
    }
    public void RepairIt()
    {
        stock.AddPart(currentPh.model, currentPh.brockenPart, -1);
        currentPh.status = true;
    }
}
