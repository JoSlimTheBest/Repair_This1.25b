using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LariseHelper : MonoBehaviour
{
    public GameObject sayPrefab;

    public void SayHelp(string whatSay)
    {
       GameObject buuble = Instantiate(sayPrefab,transform.position,transform.rotation,transform);
        buuble.transform.localPosition = new Vector3(-2.5f, -0.4f, 0);
        buuble.GetComponentInChildren<TextMeshPro>().text = whatSay;
    }
}
