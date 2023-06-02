using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SimpleLocalizator;

public class FirstDialog : MonoBehaviour
{

    public List<string> nextDialogRus = new List<string>();
    public List<string> nextDialogEng = new List<string>();
    public GameObject dialogprefab;

    public List<string> denayOrderRus;
    public List<string> denayOrderEng;


    public List<string> denayByTimeRus;
    public List<string> denayByTimeEng;
   
    public List<string> denayByMoneyRus;
    public List<string> denayByMoneyEng;


    public string agreedRus;
    public string agreedEng;

    public GameObject dialogChanger;
    public float xOffset;
    public float yOffset;
    public float topperDialog;
    public int dialogDestroy = 4;

    private int countDialog = 0;

    private List<GameObject> enterDialog = new List<GameObject>();
    private AudioSource audioS;
    public AudioClip saySome;

    public GameObject gift;
    private GameObject placeForGift;

    public bool readySpeak;
    


    public void Start()
    {
        
        audioS = GameObject.Find("AudioEvent").GetComponent<AudioSource>();
        placeForGift = GameObject.Find("PlaceForGift");
        
    }

    
    public void DialogStart()
    {
        GetComponent<HumanCharacter>().EquelTime();
        if(countDialog >= nextDialogRus.Count)
        {
            if(gift != null)
            {
                GameObject gifter = Instantiate(gift, placeForGift.transform);
                if (gifter.GetComponent<BrokenPhone>() != null)
                {
                    gifter.GetComponent<BrokenPhone>().brockenPart = GetComponent<HumanCharacter>()._brokenPartPhone;
                    gifter.GetComponent<BrokenPhone>().model = GetComponent<HumanCharacter>()._brokenModelPhone;
                }

                if (gifter.GetComponent<BoxDelivery>() != null)
                {
                    gifter.GetComponent<BoxDelivery>().namePartDelivery = GetComponent<HumanCharacter>()._brokenPartPhone;
                    gifter.GetComponent<BoxDelivery>().modelDelivery = GetComponent<HumanCharacter>()._brokenModelPhone;
                    gifter.transform.position += new Vector3(-2, 0, 0);
                    gifter.GetComponent<BoxDelivery>().deliverMan = gameObject;
                }

                if(gifter.GetComponent<DismantlePhone>()!= null)
                {
                    gifter.GetComponent<DismantlePhone>().price = GetComponent<HumanCharacter>().moneyBuyer;
                    gifter.GetComponent<DismantlePhone>().modelPhone = GetComponent<HumanCharacter>()._brokenModelPhone;
                }

                if (gifter.GetComponent<EnvelopLandLord>() != null)
                {
                    gifter.GetComponent<EnvelopLandLord>().llord = gameObject;
                    gifter.transform.position += new Vector3(-6.4f, 0, 0);
                }

                gift = null;
            }
            else
            {
                if (readySpeak == true)
                {
                    GetComponent<DialogRemove>().StartReDialog();
                }   
                
            }
            
            return;
        }
       
        
        
        GameObject currentDialog = Instantiate(dialogprefab,transform.position,transform.rotation, dialogChanger.transform);
        currentDialog.transform.localPosition += new Vector3(xOffset, yOffset);
        currentDialog.transform.Rotate(0, 0, Random.Range(-2, 3));
        Destroy(currentDialog, dialogDestroy);
        if (LanguageManager.currentLang == Language.English)
        {
            currentDialog.GetComponentInChildren<Transform>().GetComponentInChildren<TextMeshPro>().text = nextDialogEng[countDialog];
        }
        else
        {
            currentDialog.GetComponentInChildren<Transform>().GetComponentInChildren<TextMeshPro>().text = nextDialogRus[countDialog];
        }
        countDialog += 1;

        enterDialog.Add(currentDialog);
        for (int i = 0;i<enterDialog.Count;i++)
        {
            if(enterDialog[i] == null)
            {
                enterDialog.Remove(enterDialog[i]);
            }
           
               
           
            
        }

        for (int i = 0; i < enterDialog.Count; i++)
        {
            if(enterDialog[i]!=null)
                enterDialog[i].transform.localPosition += new Vector3(0, topperDialog);

        }

        audioS.PlayOneShot(saySome);

    }

    public void DialogDenayOrder()
    {
        GameObject currentDialog = Instantiate(dialogprefab, transform.position, transform.rotation, dialogChanger.transform);
        currentDialog.transform.localPosition += new Vector3(xOffset, yOffset);
        currentDialog.transform.Rotate(0, 0, Random.Range(-2, 3));
        Destroy(currentDialog, dialogDestroy);
        if (LanguageManager.currentLang == Language.English)
        {
            currentDialog.GetComponentInChildren<Transform>().GetComponentInChildren<TextMeshPro>().text = denayOrderEng[Random.Range(0, denayOrderEng.Count)];
        }
        else
        {
            currentDialog.GetComponentInChildren<Transform>().GetComponentInChildren<TextMeshPro>().text = denayOrderRus[Random.Range(0, denayOrderRus.Count)];
        }

        audioS.PlayOneShot(saySome);
    }

    public void DenayByTime()
    {
        GameObject currentDialog = Instantiate(dialogprefab, transform.position, transform.rotation, dialogChanger.transform);
        currentDialog.transform.localPosition += new Vector3(xOffset, yOffset);
        currentDialog.transform.Rotate(0, 0, Random.Range(-2, 3));
        Destroy(currentDialog, dialogDestroy);
        if (LanguageManager.currentLang == Language.English)
        {
            currentDialog.GetComponentInChildren<Transform>().GetComponentInChildren<TextMeshPro>().text = denayByTimeEng[Random.Range(0, denayByTimeEng.Count)];
        }
        else
        {
            currentDialog.GetComponentInChildren<Transform>().GetComponentInChildren<TextMeshPro>().text = denayByTimeRus[Random.Range(0, denayByTimeRus.Count)];
        }

        audioS.PlayOneShot(saySome);
    }
    public void DenayByMoney()
    {
        GameObject currentDialog = Instantiate(dialogprefab, transform.position, transform.rotation, dialogChanger.transform);
        currentDialog.transform.localPosition += new Vector3(xOffset, yOffset);
        currentDialog.transform.Rotate(0, 0, Random.Range(-2, 3));
        Destroy(currentDialog, dialogDestroy);
        if (LanguageManager.currentLang == Language.English)
        {
            currentDialog.GetComponentInChildren<Transform>().GetComponentInChildren<TextMeshPro>().text = denayByMoneyEng[Random.Range(0, denayByMoneyEng.Count)];
        }
        else
        {
            currentDialog.GetComponentInChildren<Transform>().GetComponentInChildren<TextMeshPro>().text = denayByMoneyRus[Random.Range(0, denayByMoneyRus.Count)];
        }

        audioS.PlayOneShot(saySome);
    }

    public void AgreedClockMoney()
    {
        GameObject currentDialog = Instantiate(dialogprefab, transform.position, transform.rotation, dialogChanger.transform);
        currentDialog.transform.localPosition += new Vector3(xOffset, yOffset);
        currentDialog.transform.Rotate(0, 0, Random.Range(-2, 3));
        Destroy(currentDialog, dialogDestroy);
        if (LanguageManager.currentLang == Language.English)
        {
            currentDialog.GetComponentInChildren<Transform>().GetComponentInChildren<TextMeshPro>().text = agreedEng;
        }
        else
        {
            currentDialog.GetComponentInChildren<Transform>().GetComponentInChildren<TextMeshPro>().text = agreedRus;
        }
        Invoke("ReadyToSpeak", 4f);

        audioS.PlayOneShot(saySome);
    }
    public void ReadyToSpeak()
    {
        readySpeak = true;
    }
}
