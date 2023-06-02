using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SimpleLocalizator;

public class DialogRemove : MonoBehaviour
{
    [Header ("ComeBackDialog") ]
    public List<string> dialogReRus =new List<string>();
    public List<string> dialogReEng = new List<string>();
    [Header("SuccessRepairDialog")]
    public List<string> happyBuyerRus = new List<string>();
    public List<string> happyBuyerEng = new List<string>();
    [Header("NoRepairDialog")]
    public List<string> dissapoinBuyerRus = new List<string>();
    public List<string> dissapoinBuyerEng = new List<string>();

    private int countDial = 0;
    public int humanIndexPhone;
    private int currentMoney;
    public GameObject dialogprefab;
    public int xOffset = 1300;
    public int yOffset = 675;
    private float topperDialog = 1.2f;
    public int dialogDestroy = 4;
    public GameObject dialogChanger;
    private AudioSource audioS;
    public AudioClip say;
    private List<GameObject> enterDialog = new List<GameObject>();
    public GameObject moneyTakePrefab;


    public void Start()
    {
        
        audioS = GameObject.Find("AudioEvent").GetComponent<AudioSource>();
        

    }
    public void StartReDialog()
    {
        if(countDial >= dialogReRus.Count)
        {
            GameObject phone = GameObject.Find("BasketBrokenPhone").GetComponent<BasketPhones>().RemovePhone(humanIndexPhone);
            if(phone != null)
            {
                currentMoney = phone.GetComponent<BrokenPhone>().moneyPaying;
                phone.transform.position = GameObject.Find("PlaceForGift").transform.position;
                if(phone.GetComponent<BrokenPhone>().status == true)
                {

                    ManagerStock stock = GameObject.Find("ManagerStock").GetComponent<ManagerStock>();
                    if (phone == stock.CheckFiles.GetComponent<FilesScreenHolder>().currPhoneFilesCheck)
                    {
                        stock.CheckFiles.GetComponentInChildren<CloseCostChanger>().Task();
                    }

                    GameObject leaveDial = Instantiate(dialogprefab, transform.position, transform.rotation, dialogChanger.transform);
                    leaveDial.transform.localPosition += new Vector3(xOffset, yOffset);
                    leaveDial.transform.Rotate(0, 0, Random.Range(-2, 3));
                    Destroy(leaveDial, dialogDestroy);
                    if (LanguageManager.currentLang == Language.English)
                    {
                        leaveDial.GetComponentInChildren<Transform>().GetComponentInChildren<TextMeshPro>().text = happyBuyerEng[Random.Range(0, happyBuyerEng.Count)];
                    }
                    else
                    {
                        leaveDial.GetComponentInChildren<Transform>().GetComponentInChildren<TextMeshPro>().text = happyBuyerRus[Random.Range(0, happyBuyerRus.Count)];
                    }
                    audioS.PlayOneShot(say);
                    Invoke("MoneyTaker",0.5f);
                    Destroy(phone, 2.3f);

                   

                }
                else
                {
                    GameObject leaveDial = Instantiate(dialogprefab, transform.position, transform.rotation, dialogChanger.transform);
                    leaveDial.transform.localPosition += new Vector3(xOffset, yOffset);
                    leaveDial.transform.Rotate(0, 0, Random.Range(-2, 3));
                    Destroy(leaveDial, dialogDestroy);
                    if (LanguageManager.currentLang == Language.English)
                    {
                        leaveDial.GetComponentInChildren<Transform>().GetComponentInChildren<TextMeshPro>().text = dissapoinBuyerEng[Random.Range(0, dissapoinBuyerEng.Count)];
                    }
                    else
                    {
                        leaveDial.GetComponentInChildren<Transform>().GetComponentInChildren<TextMeshPro>().text = dissapoinBuyerRus[Random.Range(0, dissapoinBuyerRus.Count)];
                    }
                    audioS.PlayOneShot(say);
                    Invoke("NoRepairPhone", 4f);
                    Destroy(phone, 2.3f);
                }
                
            }

            return;
        }
       

       
        
        GameObject currentDialog = Instantiate(dialogprefab, transform.position, transform.rotation, dialogChanger.transform);
        currentDialog.transform.localPosition += new Vector3(xOffset, yOffset);
        currentDialog.transform.Rotate(0, 0, Random.Range(-2, 3));
        enterDialog.Add(currentDialog);

        TopDialog();
        Destroy(currentDialog, dialogDestroy);
        if (LanguageManager.currentLang == Language.English)
        {
            currentDialog.GetComponentInChildren<Transform>().GetComponentInChildren<TextMeshPro>().text = dialogReEng[countDial];
        }
        else
        {
            currentDialog.GetComponentInChildren<Transform>().GetComponentInChildren<TextMeshPro>().text = dialogReRus[countDial];
        }
        audioS.PlayOneShot(say);
        countDial += 1;
    }


    private void TopDialog()
    {
        for (int i = 0; i < enterDialog.Count; i++)
        {
            if (enterDialog[i] == null)
            {
                enterDialog.Remove(enterDialog[i]);
            }




        }

        for (int i = 0; i < enterDialog.Count; i++)
        {
            if (enterDialog[i] != null)
                enterDialog[i].transform.localPosition += new Vector3(0, topperDialog);

        }
    }


    public void MoneyTaker()
    {
        GameObject mon = Instantiate(moneyTakePrefab);
        mon.GetComponent<MoneyTakeCharacter>().countMoney = currentMoney;
        mon.transform.position = GameObject.Find("PlaceForGift").transform.position + new Vector3(-1.5f, 0f, 0f);


        if( GetComponent<HumanCharacter>().moneyBuyer - currentMoney <= 0 && GetComponent<HumanCharacter>().previewMoneyBuyer != 0)
        {
            GameObject.Find("Player").GetComponent<PlayerCharacter>().AddRaiting(3, GetComponent<RewiewStar>().GiveStar(3),gameObject.GetComponent<HumanCharacter>().myFace);
        }
        else
        {
            int r = Random.Range(4, 6);
            GameObject.Find("Player").GetComponent<PlayerCharacter>().AddRaiting(r, GetComponent<RewiewStar>().GiveStar(r), gameObject.GetComponent<HumanCharacter>().myFace);
        }
        
        
    }

    public void NoRepairPhone()
    {
        GameObject.Find("QueueControll").GetComponent<HumanQueue>().HumanExitAngry();
    }
}
