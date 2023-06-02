using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RedCountMessages : MonoBehaviour
{
    public int countNewMess = 0;


    private void FixedUpdate()
    {
        GetComponent<TextMeshProUGUI>().text = countNewMess.ToString();
    }
}
