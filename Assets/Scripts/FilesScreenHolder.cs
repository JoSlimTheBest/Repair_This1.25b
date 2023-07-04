using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilesScreenHolder : MonoBehaviour
{
    public GameObject noActivePhone;
    public GameObject namingActive;
    public GameObject currPhoneFilesCheck;

    public GameObject contact;
    public GameObject message;
    public GameObject pictures;

    public void Active(GameObject phone)
    {
        namingActive.SetActive(true);
        noActivePhone.SetActive(false);

        currPhoneFilesCheck = phone;

        InstAllFiles();
    }

    public void NotActive(GameObject phone)
    {
        currPhoneFilesCheck = phone;
        noActivePhone.SetActive(true);
        namingActive.SetActive(false);
    }


    public void InstAllFiles()
    {
        List<GameObject> contactsF = currPhoneFilesCheck.GetComponent<PhonePrivateInf>().contacts;
        for (int i = 0; i < contactsF.Count; i++)
        {
            GameObject cont = Instantiate(contactsF[i], contact.transform.position + new Vector3(0, -60 * i, 0), Quaternion.identity, contact.transform);
            cont.GetComponent<RectTransform>().localPosition = new Vector3(0, -60 * i, 0);
        }
        List<GameObject> messageF = currPhoneFilesCheck.GetComponent<PhonePrivateInf>().messages;
        for (int i = 0; i < messageF.Count; i++)
        {
            GameObject cont = Instantiate(messageF[i], message.transform.position + new Vector3(0, -60 * i, 0), Quaternion.identity, message.transform);
            cont.GetComponent<RectTransform>().localPosition = new Vector3(0, -60 * i, 0);
        }
        List<GameObject> picturesF = currPhoneFilesCheck.GetComponent<PhonePrivateInf>().pictures;
        for (int i = 0; i < picturesF.Count; i++)
        {
            GameObject cont = Instantiate(picturesF[i], pictures.transform.position + new Vector3(0, -60 * i, 0), Quaternion.identity, pictures.transform);
            cont.GetComponent<RectTransform>().localPosition = new Vector3(0, -60 * i, 0);
        }

        contact.SetActive(false);
        message.SetActive(false);
        pictures.SetActive(false);

    }

    public void DestroyAll()
    {
        Debug.Log("Destroying");
        List<GameObject> TList = new List<GameObject>();
        for (int i = 0; i < contact.transform.childCount; i++)
        {
            TList.Add(contact.transform.GetChild(i).gameObject);
        }
        
        for (int i = 0; i < message.transform.childCount; i++)
        {
            TList.Add(message.transform.GetChild(i).gameObject);
        }

       
        
        for (int i = 0; i < pictures.transform.childCount; i++)
        {
            TList.Add(pictures.transform.GetChild(i).gameObject);
        }

        foreach (GameObject child in TList)
        {
            Destroy(child, 0f);
        }

    }
}
