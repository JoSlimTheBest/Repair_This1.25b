using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LeaveMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(EndGame);
    }

    public void EndGame()
    {
        GameObject.Find("Player").GetComponent<PlayerStatistic>().EndGame(0);
        SceneManager.LoadScene(0);
    }

    
}
