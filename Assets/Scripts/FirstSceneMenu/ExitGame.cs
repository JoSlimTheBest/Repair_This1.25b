using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ExitGame : MonoBehaviour
{


    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(Exit);
    }

    private void Exit()
    {
        Application.Quit();
    }
}
