using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrivateScreen2 : MonoBehaviour
{
    public GameObject holderMenu2Screen;

    public FilesScreenHolder checker;
    public GameObject opening;
    public GameObject close1;
    public GameObject close2;

    public void Start()
    {
        checker = GameObject.Find("CheckFiles").GetComponent<FilesScreenHolder>();
        GetComponent<Button>().onClick.AddListener(OpenMenu);
    }
    public void Desrtoing()
    {
       /* List<GameObject> TList = new List<GameObject>();
        for (int i = 0; i < holderMenu2Screen.transform.childCount; i++)
        {
            TList.Add(holderMenu2Screen.transform.GetChild(i).gameObject);
        }

        foreach (GameObject child in TList)
        {
            Destroy(child, 0f);
        }
       */
    }
    public void OpenMenu()
    {
        // Desrtoing();
        opening.SetActive(true);
        close1.SetActive(false);
        close2.SetActive(false);
        holderMenu2Screen.GetComponent<PrivateScreen3>().CloseAll();


        /*
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
        */

    }
}
