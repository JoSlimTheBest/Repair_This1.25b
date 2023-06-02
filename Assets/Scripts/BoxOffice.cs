using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SimpleLocalizator;

public class BoxOffice : MonoBehaviour
{
    public GameObject billCheck;
    public TextMeshProUGUI textBill;
    public GameObject moneyChoice;
    private PlayerCharacter player;
    public AudioClip openOffice;
    public int dayMoney = 0;
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OpenBoxOffice);
        player = GameObject.Find("Player").GetComponent<PlayerCharacter>();
    }
    public void OpenBoxOffice()
    {
        if (moneyChoice.activeSelf == true)
        {
            billCheck.GetComponent<Button>().enabled = true;
            billCheck.GetComponent<Image>().color = new Color(0, 0.8f, 0);
            int money = player.choiceMoneyAdd;
            int tax = player.tax;
            if (LanguageManager.currentLang == Language.English)
            {
                textBill.text = "Money " + money + "\n" + "Profit " + (money - money / tax) + "\n" + "Tax " + (money / tax);

            }
            else
            {
                textBill.text = "Деньги " + money + "\n" + "Прибыль " + (money - money / tax) + "\n" + "Налог " + (money / tax);
            }

        }
        else
        {
            billCheck.GetComponent<Button>().enabled = false;
            billCheck.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f);
            textBill.text = "Hello World!" + "\n" + "Привет Мир!";
            

        }

        GameObject.Find("AudioEvent").GetComponent<AudioSource>().PlayOneShot(openOffice);
    }

    public void OpenBill()
    {

    }
}
