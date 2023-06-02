using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanQueue : MonoBehaviour
{
    
    public GameObject firstMan;
    public GameObject secondMan;


    public GameObject answerHuman;

    public List<GameObject> humanList = new List<GameObject>();
    public DoorController door;

    private ComputerTime timing;
    public bool computerActive = false;


    private int currentAddTime;
    private int currentMoney;

    public bool block2place = false;

    private bool angryMenSwitch = false;

    private LandLord lord;

    public void Start()
    {
        door = GameObject.Find("door").GetComponent<DoorController>();
        timing = GetComponent<ComputerTime>();
    }
    public void HumanEventList(GameObject human)
    {

        if (human.GetComponent<LandLord>() != null)
        {
            block2place = true;
            lord = human.GetComponent<LandLord>();
            if(humanList.Count > 0)
            {

                if(humanList.Count > 1)
                {
                    human.GetComponent<LandLord>().wait = true;
                    return;
                }
                else
                {
                    
                    human.GetComponent<HumanCharacter>().ActivetingAnim();
                    human.GetComponent<HumanCharacter>().dial.enabled = true;
                    human.GetComponent<HumanCharacter>().ChangeActiveColor(true);
                    bool dor = human.GetComponent<Animator>().GetBool("Queue");
                    human.GetComponent<LandLord>().wait = false;
                    if (dor == false)
                    {
                        human.GetComponent<Animator>().SetBool("Queue", true);
                        door.DoorEvent();
                        
                    }
                }
            }
            else
            {
                human.GetComponent<HumanCharacter>().ActivetingAnim();
                human.GetComponent<HumanCharacter>().dial.enabled = true;
                human.GetComponent<HumanCharacter>().ChangeActiveColor(true);
                bool dor = human.GetComponent<Animator>().GetBool("Queue");
                if (dor == false)
                {
                    human.GetComponent<Animator>().SetBool("Queue", true);
                    door.DoorEvent();
                }
                human.GetComponent<LandLord>().wait = false;



                
            }
            return;
        }


        humanList.Add(human);
        
        
        if(humanList[0].GetComponent<HumanCharacter>().activeAnim == false)
        {

            humanList[0].GetComponent<HumanCharacter>().ActivetingAnim();
            humanList[0].GetComponent<HumanCharacter>().dial.enabled = true;
            humanList[0].GetComponent<HumanCharacter>().ChangeActiveColor(true);
            
            bool dor = humanList[0].GetComponent<Animator>().GetBool("Queue");
            if (dor == true)
            {
                humanList[0].GetComponent<Animator>().SetBool("Queue", false);
                door.DoorEvent();
            }

            if (block2place == true && lord != null)
            {
                lord.Comment(humanList[0].GetComponent<HumanCharacter>());
            }


        }

        Invoke("NextHuman", 4f);


    }
    public void HumanExitAngry()
    {
        if (humanList.Count == 0) { return; }
        
        Destroy(humanList[0], 2f);

        //humanList[0].GetComponent<FirstDialog>().DialogDenayOrder();

        if (GameObject.Find("PlaceCheckPhone").GetComponentInChildren<BrokenPhone>() != null)
        {
            GameObject.Find("PlaceCheckPhone").GetComponentInChildren<BrokenPhone>().DisAgreePhone();
            Debug.Log("CHECK111");
        }
        TaskTime();

        angryMenSwitch = true;
        int f = Random.Range(0, 2);
        if (f > 0)
        {
            
        }
        
    }
    private void TaskTime()
    {
        humanList[0].GetComponent<HumanCharacter>().ChangeSpriteLayer(100);
        humanList[0].GetComponent<Animator>().SetBool("ExitTime", true);

        GameObject.Find("Player").GetComponent<PlayerCharacter>().AddRaiting(1,humanList[0].GetComponent<RewiewStar>().GiveStar(1), humanList[0].GetComponent<HumanCharacter>().myFace);
        humanList.Remove(humanList[0]);


        
        
        



        Invoke("NextQ", 1f);
        Invoke("DoorExit", 1.25f);
        Invoke("NextHuman", 4f);

    }

    public void HumanExit(GameObject currentMan)
    {
        Debug.Log("Delivery must Exit");
        if(humanList[0] == currentMan)
        {
            Debug.Log("DeliveryFirst");
            HumanExit();
            return;
        }
      
        Debug.Log("DeliveryRealExit");
        
        for (int h= 0; h < humanList.Count; h++)
        {
            if(humanList[h]==currentMan)
            {
                Destroy(humanList[h], 0.75f);
                humanList[h].GetComponent<HumanCharacter>().ChangeSpriteLayer(100);
                humanList[h].GetComponent<Animator>().SetBool("ExitTime", true);
                humanList[h].GetComponent<Animator>().SetBool("Deliver", true);

                humanList.Remove(humanList[h]);



                Invoke("DoorExit", 0.2f);
                Invoke("NextHuman", 4f);
            }
        }

    }

    public void ChangeLock(bool open)
    {
        if(open == true)
        {
            block2place = false;
            lord = null;
            Invoke("NextQ", 1f);
            Invoke("DoorExit", 1.25f);
            

        }
    }
    public void HumanExit()
    {
        if (humanList.Count == 0) { return; }
        
        Destroy(humanList[0], 2f);
        humanList[0].GetComponent<HumanCharacter>().ChangeSpriteLayer(100);
        humanList[0].GetComponent<Animator>().SetBool("ExitTime", true);
        
        humanList.Remove(humanList[0]);

       
        
        Invoke("NextQ", 1f);
        Invoke("DoorExit", 1.25f);
        Invoke("NextHuman", 4f);
      
    }
    public void ComputerActive(bool act)
    {
        computerActive = act;
    }
    private void DoorExit()
    {
        door.DoorEvent();
    }
    private void NextQ()
    {
        if (humanList.Count > 0)
        {
            humanList[0].GetComponent<HumanCharacter>().ActivetingAnim();
            humanList[0].GetComponent<HumanCharacter>().ChangeSpriteLayer(-50);
            humanList[0].GetComponent<Animator>().SetBool("Queue", false);
            humanList[0].GetComponent<HumanCharacter>().dial.enabled = true;
            humanList[0].GetComponent<HumanCharacter>().ChangeActiveColor(true);

            if (block2place == true && lord != null)
            {
                lord.Comment(humanList[0].GetComponent<HumanCharacter>());
            }
        }
        if (angryMenSwitch == true)
        {
            GameObject.Find("Switcher").GetComponent<Switcher>().ChangerA();
            angryMenSwitch = false;
        }

    }
    private void NextHuman()
    {
        
        if (humanList.Count > 1 && block2place == false)
        {
            if (humanList[1].GetComponent<HumanCharacter>().activeAnim == false)
            {
                humanList[1].GetComponent<HumanCharacter>().ActivetingAnim();
                humanList[1].GetComponent<HumanCharacter>().ChangeSpriteLayer(50);
                door.DoorEvent();
            }

        }
    }

    public void ComputerActiveChanger(bool timeslow)
    {
        computerActive = timeslow;
    }


    private void FixedUpdate()
    {
        if (humanList.Count > 0 && timing.slowTime == false && computerActive == false)
        {
            
            timing.ChangeTimeSlow(true);
        }

        if(humanList.Count <= 0 && timing.slowTime == true && computerActive == false)
        {

            timing.ChangeTimeSlow(false);
        }
    }


    public void HumanQuest(int c, int t)
    {
        int humanMoney = humanList[0].GetComponent<HumanCharacter>().moneyBuyer;
        int humanTime = humanList[0].GetComponent<HumanCharacter>().clock;
        bool agreed = true;
        //add penalty to clockTimeHuman
        if (humanTime < t)
        {
           
            humanList[0].GetComponent<FirstDialog>().DenayByTime();

            GameObject asked = Instantiate(answerHuman, humanList[0].transform.position, Quaternion.identity);
            asked.GetComponent<AnswerHumanFact>().denayByTime = true;

            agreed = false;
            GameObject.Find("PlaceCheckPhone").GetComponentInChildren<BrokenPhone>().DisAgreePhone();
            Invoke("HumanExit", 2f);
            
            GameObject.Find("Player").GetComponent<PlayerCharacter>().AddRaiting(2, humanList[0].GetComponent<RewiewStar>().GiveStar(2),humanList[0].GetComponent<HumanCharacter>().myFace);
        }
        if (humanMoney < c && agreed == true)
        {
            GameObject asked = Instantiate(answerHuman, humanList[0].transform.position, Quaternion.identity);
            asked.GetComponent<AnswerHumanFact>().denayByCost = true;
            humanList[0].GetComponent<FirstDialog>().DenayByMoney();
            agreed = false;
            GameObject.Find("PlaceCheckPhone").GetComponentInChildren<BrokenPhone>().DisAgreePhone();
            

            Invoke("HumanExit", 2f);
            int r = Random.Range(1, 3);
            GameObject.Find("Player").GetComponent<PlayerCharacter>().AddRaiting(2, humanList[0].GetComponent<RewiewStar>().GiveStar(2), humanList[0].GetComponent<HumanCharacter>().myFace);
        }

        if (agreed == true)
        {

            GameObject asked = Instantiate(answerHuman, humanList[0].transform.position, Quaternion.identity);
            asked.GetComponent<AnswerHumanFact>().agreed = true;
            currentAddTime = t;
            currentMoney = c;
            
            humanList[0].GetComponent<FirstDialog>().AgreedClockMoney();
            Invoke("HumanExitAndRegoing", 2f);
        }

        
    }

    private void HumanExitAndRegoing()
    {
        if (humanList.Count == 0) { return; }

        humanList[0].GetComponent<HumanCharacter>().ChangeSpriteLayer(100);
        humanList[0].GetComponent<Animator>().SetBool("ExitTime", true);
        humanList[0].GetComponent<FirstDialog>().enabled = false;
        humanList[0].GetComponent<HumanCharacter>().DRemove.enabled = true;
        humanList[0].GetComponent<HumanCharacter>().DRemove.humanIndexPhone = GameObject.Find("Player").GetComponent<TransNamePartPhone>().phoneIndex;
        humanList[0].GetComponent<HumanCharacter>().hour = GetComponent<ComputerTime>().hours + currentAddTime;
        if(humanList[0].GetComponent<HumanCharacter>().hour > 22)
        {
            humanList[0].GetComponent<HumanCharacter>().day += 1;
            humanList[0].GetComponent<HumanCharacter>().hour = Random.Range(11, 18);
        }
        humanList[0].GetComponent<HumanCharacter>().minute = (int)GetComponent<ComputerTime>().minute;
        GameObject.Find("PlaceCheckPhone").GetComponentInChildren<BrokenPhone>().AgreeClientGoBoxPhone(currentMoney, humanList[0].GetComponent<HumanCharacter>().myFace);

        Invoke("DoorExit", 1.25f);
        Invoke("HideHuman", 2f);
    }

    private void HideHuman()
    {
        humanList[0].transform.position = new Vector3(20, 0, 0);
        humanList[0].GetComponent<Animator>().enabled = false;
        humanList[0].GetComponent<Animator>().SetBool("ExitTime", false);
        humanList[0].GetComponent<Animator>().SetBool("Queue", true);
        humanList[0].GetComponent<HumanCharacter>().ChangeActiveColor(false);
        humanList[0].GetComponent<HumanCharacter>().activeAnim = false;
        humanList[0].GetComponent<HumanCharacter>().ChangeSpriteLayer(-100);
        GetComponent<ComputerTime>().Addheroes(humanList[0]);
        humanList.Remove(humanList[0]);
        NextQ();
        

    }

}
