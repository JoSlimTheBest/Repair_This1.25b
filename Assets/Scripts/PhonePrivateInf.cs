using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhonePrivateInf : MonoBehaviour
{
    public enum openInf {no, yes }
    public openInf info;


    public List<GameObject> contacts = new List<GameObject>();
    public List<GameObject> messages = new List<GameObject>();
    public List<GameObject> pictures = new List<GameObject>();
}
