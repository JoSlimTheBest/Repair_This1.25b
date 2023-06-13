using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckFiles : MonoBehaviour
{

    public GameObject checkFilesDevice;

    public GameObject phoneCheckFiles;



   
    
    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(Task);
        checkFilesDevice = GameObject.Find("ManagerStock").GetComponent<ManagerStock>().CheckFiles;
    }

    public void Task()
    {

        RepairList rp = GameObject.Find("RepairList").GetComponent<RepairList>();
        rp.CloseTable();
        rp.gameObject.SetActive(false);
        checkFilesDevice.SetActive(true);
        InitializationPhoneFiles();
    }


    public void InitializationPhoneFiles()
    {
        if(phoneCheckFiles.GetComponent<PhonePrivateInf>() != null)
        {
            if((int)phoneCheckFiles.GetComponent<PhonePrivateInf>().info == 1)
            {
                checkFilesDevice.GetComponent<FilesScreenHolder>().Active(phoneCheckFiles);
                
            }
            else
            {
                checkFilesDevice.GetComponent<FilesScreenHolder>().NotActive(phoneCheckFiles);
            }
        }
        else
        {
            checkFilesDevice.GetComponent<FilesScreenHolder>().NotActive(phoneCheckFiles);
        }
    }


    
}


