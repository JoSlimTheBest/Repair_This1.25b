using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppliqationQuit : MonoBehaviour
{
    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(Quit);
    }


    private void Quit()
    {
        Application.Quit();
    }
}
