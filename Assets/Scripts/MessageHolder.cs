using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageHolder : MonoBehaviour
{
    public List<GameObject> messages = new List<GameObject>();
    public GameObject parentMessages;
    public int spaceForMess = 100;
    public int currentMessage = 0;
    public int direction = 350;

    public RedCountMessages redCount;


    public GameObject currentMessageField;

    public GameObject dataPass;
    public GameObject deleteBut;
    public GameObject sign2;



    public AudioClip message;


   
    public void AddMessages(GameObject mess)
    {
        


        GameObject newM = Instantiate(mess, parentMessages.transform.position, transform.rotation, parentMessages.transform);
        messages.Add(newM);
        newM.GetComponent<MessageCharacter>().currentField = currentMessageField;
        newM.GetComponent<MessageCharacter>().dataGet = dataPass;
        newM.GetComponent<MessageCharacter>().redCountM = redCount;
        newM.GetComponent<MessageCharacter>().buttonDelete = deleteBut;

        redCount.countNewMess += 1;
        GameObject.Find("AudioEvent").GetComponent<AudioSource>().PlayOneShot(message);
        for (int i = 0; i<messages.Count; i++)
        {
            sign2.SetActive(true);

            messages[i].GetComponent<RectTransform>().localPosition = new Vector3(0, direction - i * spaceForMess);

            

        }

       


        
    }


    public void Closer()
    {
        currentMessageField.GetComponentInChildren<TextMeshProUGUI>().text = " ";
    }
    public void DestroyAllMess()
    {
        for (int i = 0; i < messages.Count; i++)
        {
            Destroy(messages[i]);
                
        }
        messages = new List<GameObject>();

        redCount.countNewMess = 0;


    }
    public void DestroyMessage(GameObject message)
    {

        for(int i = 0; i < messages.Count; i++)
        {
            if(messages[i] == message)
            {
                Destroy(messages[i]);
                messages.Remove(messages[i]);
               

            }
        }

        for (int i = 0; i < messages.Count; i++)
        {

            messages[i].GetComponent<RectTransform>().localPosition = new Vector3(0, direction - i * spaceForMess);

            Debug.Log(direction - i * spaceForMess + messages[i].name + parentMessages.transform.localPosition);

        }
        currentMessageField.GetComponentInChildren<TextMeshProUGUI>().text = " ";
        

    }

    public void MessagesOnDisplay()
    {
        /*
        for(int i = 0; i<messages.Count; i++)
        {
            GameObject newM = Instantiate(messages[i], parentMessages.transform.position, transform.rotation, parentMessages.transform);
            newM.GetComponent<RectTransform>().transform.localPosition += new Vector3(0, 400 - i * 100);
            
        }
        */
    }
}
