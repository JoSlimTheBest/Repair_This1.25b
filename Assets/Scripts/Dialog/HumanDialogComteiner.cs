using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SimpleLocalizator;

public class HumanDialogComteiner : MonoBehaviour
{
    public List<string> dialogsRus = new List<string>();
    public List<string> dialogEng = new List<string>();

    public GameObject prefabDialog;


    public void DialogEnter()
    {
      GameObject dialogEnter =  Instantiate(prefabDialog, transform);
        dialogEnter.transform.localPosition = new Vector3(-300, 100);
    }
}
