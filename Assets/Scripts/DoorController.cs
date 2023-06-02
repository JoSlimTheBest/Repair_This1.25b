
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class DoorController : MonoBehaviour
{
    public Sprite closeDoor;
    public Sprite halfOpenDoor;
    public Sprite openDoor;

    public bool openD;
    public float speedOpen;
    public List<GameObject> prefabBuyers;
    public List<GameObject> prefabTrash;


    public int endCountHuman;

    public bool ramdomHuman =false;
    public bool llord = false;
    public GameObject prefabHuman;

    public GameObject llFg;
    public AudioClip doorOpenAudio; 
    public AudioClip doorCloseAudio;

    private int changerPos = 80;
    private int changeMin = 5;

    public void Start()
    {
        CloseDoor();

      

         prefabBuyers = Resources.LoadAll<GameObject>("HumanPrefab/RepairPhoneHuman").ToList();
         prefabTrash= Resources.LoadAll<GameObject>("HumanPrefab/TrashHuman").ToList();

        if (GameObject.Find("QueueControll").GetComponent<ComputerTime>().currentDay == 1)
        {
            LLFirstGo();
        }
    }

    public void LLFirstGo()
    {
        GameObject humanNew = Instantiate(llFg, transform.position + new Vector3(-changerPos, 0, 0), transform.rotation);

        changerPos += changeMin;




    }

    public void LLTakeMoney()
    {
        GameObject llordy = Resources.Load<GameObject>("ActiveHuman/LandLord");
        Instantiate(llordy, transform.position + new Vector3(-changerPos, 0, 0), transform.rotation);
        changerPos += changeMin;
        llordy.GetComponent<HumanCharacter>().day = GameObject.Find("QueueControll").GetComponent<ComputerTime>().currentDay; 
    }

    public void HumanInsta(GameObject human)
    {
        GameObject humanNew = Instantiate(human, transform.position + new Vector3(-changerPos, 0, 0), transform.rotation);
        Debug.Log(humanNew.transform.position);
        changerPos += changeMin;
        if (humanNew.GetComponent<HumanCharacter>().day == 0)
        {
            humanNew.GetComponent<HumanCharacter>().day = GameObject.Find("QueueControll").GetComponent<ComputerTime>().currentDay;

            if(humanNew.GetComponent<HumanCharacter>().hour == 0)
            {
                humanNew.GetComponent<HumanCharacter>().hour = Random.Range(10, 19);
            }
                
            humanNew.GetComponent<HumanCharacter>().minute = Random.Range(0, 59);
        }
    }

    public void HumanInsta()
    {
        if (ramdomHuman == true)
        {
            GameObject humanNew =  Instantiate(prefabHuman, transform.position + new Vector3(-changerPos, 0, 0), transform.rotation);
            changerPos += changeMin;
            if (humanNew.GetComponent<HumanCharacter>().day == 0)
            {
                humanNew.GetComponent<HumanCharacter>().day = GameObject.Find("QueueControll").GetComponent<ComputerTime>().currentDay;
                if (humanNew.GetComponent<HumanCharacter>().hour == 0)
                {
                    humanNew.GetComponent<HumanCharacter>().hour = Random.Range(10, 19);
                }
                humanNew.GetComponent<HumanCharacter>().minute = Random.Range(0, 59);
            }
            
        }
        else
        {
            int randomHumanity = Random.Range(0, prefabBuyers.Count);
            GameObject humanNew= Instantiate(prefabBuyers[randomHumanity], transform.position + new Vector3(-changerPos, 0, 0), transform.rotation);
            prefabBuyers.Remove(prefabBuyers[randomHumanity]);
            if(prefabBuyers.Count == 0)
            {
                prefabBuyers = new List<GameObject>();
                prefabBuyers = Resources.LoadAll<GameObject>("HumanPrefab").ToList();
            }
            changerPos += changeMin;
            if (humanNew.GetComponent<HumanCharacter>().day == 0)
            {
                humanNew.GetComponent<HumanCharacter>().day = GameObject.Find("QueueControll").GetComponent<ComputerTime>().currentDay;
                humanNew.GetComponent<HumanCharacter>().hour = Random.Range(10, 19);
                humanNew.GetComponent<HumanCharacter>().minute = Random.Range(0, 59);
            }
        }
       
    }
    public void DoorEvent()
    {
        OpenDoor();
        openD = true;
        

        GetComponent<AudioSource>().PlayOneShot(doorOpenAudio);
    }

    private void OpenDoor()
    {
        GetComponent<SpriteRenderer>().sprite = halfOpenDoor;
      
        Invoke("OpenedDoor", 0.1f);
    }

    private void OpenedDoor()
    {
        GetComponent<SpriteRenderer>().sprite = openDoor;
        Invoke("CloseHalfDoor", 0.7f);
        GetComponent<AudioSource>().PlayOneShot(doorCloseAudio);
    }
    private void CloseHalfDoor()
    {
        
        GetComponent<SpriteRenderer>().sprite = halfOpenDoor;
        Invoke("CloseDoor", 0.1f);
        
    }
    private void CloseDoor()
    {
        GetComponent<SpriteRenderer>().sprite = closeDoor;
    }

    private void FixedUpdate()
    {
        if(changerPos >= 120)
        {
            changerPos = 80;
        }
    }
}
