using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenPhone : MonoBehaviour
{
    public string model;
    public int brockenPart = -1;

    public Sprite modelA;
    public Sprite modelM;
    public Sprite modelS;


    public Sprite wireA;
    public Sprite wireM;
    public Sprite wireS;

    public SpriteRenderer display;
    public Sprite dispA;
    public Sprite dispM;
    public Sprite dispS;

    private GameObject player;
    private bool activePhoneTake = true;

    private CostChangerCharacter changers;
    public int index;
    public int moneyPaying;

    public bool status = false;


    private GameObject device;

    public Sprite humanPhotoHere;
    void Start()
    {
     
        device = GameObject.Find("device");
        player = GameObject.Find("Player");
        player.GetComponent<TransNamePartPhone>().phoneIndex += 1;
        index = player.GetComponent<TransNamePartPhone>().phoneIndex;
        /*if (model != "A" || model != "M" || model != "S" )
        {
            int r = Random.Range(0, 3);
            if(r == 0)
            {
                model = "A";
                
            }

            if (r == 1)
            {
                model = "M";

            }
            if (r == 2)
            {
                model = "S";

            }
           

        }
        */

        if(model == "A")
        {
            GetComponent<SpriteRenderer>().sprite = modelA;
            display.sprite = dispA;
        }
        if (model == "M")
        {
            GetComponent<SpriteRenderer>().sprite = modelM;
            display.sprite = dispM;
        }
        if (model == "S")
        {
            GetComponent<SpriteRenderer>().sprite = modelS;
            display.sprite = dispS;
        }
        display.gameObject.SetActive(false);
        if (brockenPart < 0)
        {
            brockenPart = Random.Range(0,player.GetComponent<TransNamePartPhone>().partNameEng.Count);


        }

    }


    public void ReplacePhone()
    {
        if(activePhoneTake == false)
        {
            return;
        }

        activePhoneTake = false;
        display.gameObject.SetActive(true);
        GetComponent<SpriteRenderer>().material.shader = Shader.Find("Sprites/Default");
        GameObject replace = GameObject.Find("PlaceCheckPhone");
        transform.position = replace.transform.position;
        transform.parent = replace.transform;
        if (model == "A")
        {
            GetComponent<SpriteRenderer>().sprite = wireA;
        }
        if (model == "M")
        {
            GetComponent<SpriteRenderer>().sprite = wireM;
        }
        if (model == "S")
        {
            GetComponent<SpriteRenderer>().sprite = wireS;
        }

        device.GetComponent<Animator>().enabled = true;
        device.GetComponent<AudioSource>().enabled = true;
        Invoke("OpenChangerCost", 2f);
    }

    private void OpenChangerCost()
    {
        
        player.GetComponent<TransNamePartPhone>().costChanger.SetActive(true);
        changers = player.GetComponent<TransNamePartPhone>().costChanger.GetComponent<CostChangerCharacter>();
        Debug.Log(brockenPart);
        changers.Changer(brockenPart, model);
        device.GetComponent<Animator>().enabled = false;
        device.GetComponent<AudioSource>().enabled = false;

       
    }


    public void AgreeClientGoBoxPhone(int moneyCurrent, Sprite humanPhoto)
    {
        moneyPaying = moneyCurrent;
        GameObject.Find("BasketBrokenPhone").GetComponent<BasketPhones>().AddRepairPhone(gameObject,humanPhoto);
        humanPhotoHere = humanPhoto;
        if (model == "A")
        {
            GetComponent<SpriteRenderer>().sprite = modelA;
            Destroy(display.gameObject);
        }
        if (model == "M")
        {
            GetComponent<SpriteRenderer>().sprite = modelM;
            Destroy(display.gameObject);
        }
        if (model == "S")
        {
            GetComponent<SpriteRenderer>().sprite = modelS;
            Destroy(display.gameObject);
        }
    }

    public void DisAgreePhone()
    {
        Destroy(gameObject, 1f);
    }
   

}
