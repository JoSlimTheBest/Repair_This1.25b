using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewDay : MonoBehaviour
{
    public ComputerTime compT;
    public DoorController doorC;
    public PlayerCharacter player;
    public GameObject systemError;
    public GameObject Xrep;
    public AudioClip checkOut;
    public List<GameObject> agentXPeople = new List<GameObject>();

    private bool husbandGo = false;

    public bool agentX;
    public bool nalogcheck;

    public void Start()
    {
        agentXPeople.Add(Resources.Load<GameObject>("ActiveHuman/Beardman"));
        agentXPeople.Add(Resources.Load<GameObject>("ActiveHuman/Blondy"));
        agentXPeople.Add(Resources.Load<GameObject>("ActiveHuman/Hairless"));
    }
    public void NewDayStart()
    {
        GetComponent<ManagerStock>().mess.DestroyAllMess();
        if(compT.hours < 22)
        {
            
            systemError.GetComponent<AutoDestroy>().DontKill();
            return;
        }

        Xrep.GetComponent<AutoDestroy>().DontKill();
        bool taxMen = Xrep.GetComponent<XReport>().CheckDay();

        if (taxMen == true && nalogcheck == false && compT.currentDay != 1)
        {
            GameObject copchecker = Resources.Load<GameObject>("ActiveHuman/TaxAgent");
            doorC.HumanInsta(copchecker);
            nalogcheck = true;
        }
        GameObject.Find("AudioEvent").GetComponent<AudioSource>().PlayOneShot(checkOut);

        compT.DayComingWindow();
        compT.hours = 9;
        compT.minute = 59;
        compT.currentDay += 1;
        compT.GetComponent<ElectricBill>().EndDay();


        if (compT.currentDay == 3 || compT.currentDay == 6 || compT.currentDay == 9 || compT.currentDay == 12|| compT.currentDay==15)
        {
            doorC.LLTakeMoney();
        }

        if(husbandGo == false)
        {
            int rand = Random.Range(0, 4);
            {
                if(rand > 2)
                {
                    GameObject husband = Resources.Load<GameObject>("ActiveHuman/Husband");
                    doorC.HumanInsta(husband);
                    husbandGo = true;
                }
            }
            
        }


        if(compT.currentDay == 2)
        {
            GameObject agentX = Resources.Load<GameObject>("ActiveHuman/AgentX");
            doorC.HumanInsta(agentX);
        }

        if(agentX == true)
        {
            int go = Random.Range(0, 2);
            if(go > 0 && agentXPeople.Count > 0)
            {
                int humanLoad = Random.Range(0, agentXPeople.Count);
                doorC.HumanInsta(agentXPeople[humanLoad]);
                agentXPeople.Remove(agentXPeople[humanLoad]);
            }
        }

        if(compT.currentDay == 10)
        {
            SceneManager.LoadScene(5);
        }

        player.GivePeopleDay();
    }
}
