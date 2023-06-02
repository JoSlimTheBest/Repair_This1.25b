using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject canvasStopGame;

    public ComputerTime compT;

    private bool stop;


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Changer();
        }
    }


    public void Changer()
    {
        if (stop == false)
        {
            canvasStopGame.SetActive(true);
            compT.gameStop = true;
            stop = true;
        }
        else
        {
            canvasStopGame.SetActive(false);
            compT.gameStop = false;
            stop = false;
        }
    }
}
