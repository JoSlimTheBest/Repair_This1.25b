using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrivateScreen2 : MonoBehaviour
{
    public GameObject holderMenu2Screen;
    



    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(OpenMenu);
    }
    public void Desrtoing()
    {
        List<GameObject> TList = new List<GameObject>();
        for (int i = 0; i < holderMenu2Screen.transform.childCount; i++)
        {
            TList.Add(holderMenu2Screen.transform.GetChild(i).gameObject);
        }

        foreach (GameObject child in TList)
        {
            Destroy(child, 0f);
        }
    }
    public void OpenMenu()
    {
        Desrtoing();
        List<GameObject> TList = new List<GameObject>();
       
        FilesScreenHolder checker = GameObject.Find("CheckFiles").GetComponent<FilesScreenHolder>();

        if (gameObject.name == "ContactsPrivate")
        {
            List<GameObject> need = checker.currPhoneFilesCheck.GetComponent<PhonePrivateInf>().contacts;
            for (int i = 0; i < need.Count; i++)
            {
                Instantiate(need[i], holderMenu2Screen.transform.position + new Vector3(0, -60 * i, 0), Quaternion.identity, holderMenu2Screen.transform);
            }
        }

        if (gameObject.name == "MessagePrivate")
        {
            List<GameObject> need = checker.currPhoneFilesCheck.GetComponent<PhonePrivateInf>().messages;
            for (int i = 0; i < need.Count; i++)
            {
                Instantiate(need[i], holderMenu2Screen.transform.position + new Vector3(0, -60 * i, 0), Quaternion.identity, holderMenu2Screen.transform);
            }
        }
        if (gameObject.name == "PicturesPrivate")
        {
            List<GameObject> need = checker.currPhoneFilesCheck.GetComponent<PhonePrivateInf>().pictures;
            for (int i = 0; i < need.Count; i++)
            {
                Instantiate(need[i], holderMenu2Screen.transform.position + new Vector3(0, -60 * i, 0), Quaternion.identity, holderMenu2Screen.transform);
            }
        }

    }
}
