using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatistic : MonoBehaviour
{

    public int currentGamer;
    public int ending = 0;


    private GameObject playerTime;
    

    public void Start()
    {

        playerTime = GameObject.Find("PlayTime");
        LoadGame();

        currentGamer += 1;
        SaveGamer();


        
    }


    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("NumberPlayers"))
        {
            currentGamer = PlayerPrefs.GetInt("NumberPlayers");
        }
       
    }
    public void SaveGamer()
    {
        PlayerPrefs.SetInt("NumberPlayers",currentGamer);
        TimeDayMoneySave();
    }

    public void EndGame(int whatTheEnd)  // 0 -leave; 1- money 2- cop 3-wins
    {
        TimeDayMoneySave();
        PlayerPrefs.SetInt("PlayerEnd" + currentGamer.ToString(), whatTheEnd);
    }

    public void CheckResultPlayer()
    {
        if (PlayerPrefs.HasKey("NumberPlayers"))
        {
            int countPlayer = PlayerPrefs.GetInt("NumberPlayers");
            List<int> result = new List<int>();
            if(countPlayer > 0)
            {
                for(int r = 0; r <= countPlayer; r++)
                {

                    if (r != 0)
                    {
                        if (PlayerPrefs.HasKey("PlayerEnd" + r))
                        {
                            result.Add(PlayerPrefs.GetInt("PlayerEnd" + r));
                        }
                        else
                        {
                            result.Add(0);
                        }
                    }
                    
                }


               
            }
        }

        
    }

    public void TimeDayMoneySave()
    {
        string currTime = playerTime.GetComponent<PlayTime>().StringTime();
        int money = GameObject.Find("Player").GetComponent<PlayerCharacter>().money;
        int day = GameObject.Find("QueueControll").GetComponent<ComputerTime>().currentDay;
        PlayerPrefs.SetString("PlTime" + currentGamer, currTime);
        PlayerPrefs.SetInt("Money" + currentGamer, money);
        PlayerPrefs.SetInt("Day" + currentGamer, day);
       
    }

}
