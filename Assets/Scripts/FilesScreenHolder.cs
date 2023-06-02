using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilesScreenHolder : MonoBehaviour
{
    public GameObject noActivePhone;
    public GameObject namingActive;
    public GameObject currPhoneFilesCheck;

    public void Active(GameObject phone)
    {
        namingActive.SetActive(true);
        noActivePhone.SetActive(false);

        currPhoneFilesCheck = phone;
    }

    public void NotActive(GameObject phone)
    {
        currPhoneFilesCheck = phone;
        noActivePhone.SetActive(true);
        namingActive.SetActive(false);
    }


    public void InitilizationPhoneCheck(GameObject phone)
    {

    }
}
