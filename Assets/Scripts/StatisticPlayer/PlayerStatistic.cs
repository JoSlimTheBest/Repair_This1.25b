using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatistic : MonoBehaviour
{

    public int currentGamer;
    public int ending = 0;

    public void Start()
    {
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
    }

    public void EndGame(int whatTheEnd)
    {
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



}
