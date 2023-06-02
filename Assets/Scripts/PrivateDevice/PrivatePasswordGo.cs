using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrivatePasswordGo : MonoBehaviour
{
    private PasswordHolder ph;
    public string currentPassword;
    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(SendPassword);
        ph = GameObject.Find("ManagerStock").GetComponent<PasswordHolder>();
    }
    public void SendPassword()
    {
        ph.password = currentPassword;
    }
}
