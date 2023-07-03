using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheckStats : MonoBehaviour
{
    public GameObject place;
    public GameObject prefabPlayerStats;
    List<GameObject> delete = new List<GameObject>();
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Task);
    }

    public void DeleteAll()
    {
        for(int i =0; i < delete.Count; i++)
        {
            Destroy(delete[i]);
        }
        delete = new List<GameObject>();
    }

    private void Task()
    {
        if (PlayerPrefs.HasKey("NumberPlayers"))
        {
            int countPlayer = PlayerPrefs.GetInt("NumberPlayers");
            List<int> resultList = new List<int>();
            List<string> timeList = new List<string>();
            List<int> moneyList = new List<int>();
            List<int> dayList = new List<int>();
            if (countPlayer > 0)
            {
                for (int r = 0; r <= countPlayer; r++)
                {

                    
                        if (PlayerPrefs.HasKey("PlayerEnd" + r))
                        {
                            resultList.Add(PlayerPrefs.GetInt("PlayerEnd" + r));
                        }
                        else
                        {
                            resultList.Add(0);
                        }

                        if (PlayerPrefs.HasKey("PlTime" + r))
                        {
                            timeList.Add(PlayerPrefs.GetString("PlTime" + r));
                        }
                        else
                        {
                            timeList.Add("none");
                        }

                        if (PlayerPrefs.HasKey("Money" + r))
                        {
                            moneyList.Add(PlayerPrefs.GetInt("Money" + r));
                        }
                        else
                        {
                            moneyList.Add(-1);
                        }

                        if (PlayerPrefs.HasKey("Day" + r))
                        {
                            dayList.Add(PlayerPrefs.GetInt("Day" + r));
                        }
                        else
                        {
                            dayList.Add(-1);
                        }
                    

                }



            }


            if(resultList.Count > 1)
            {
                
                for(int i = 0; i < resultList.Count; i++)
                {
                    
                    GameObject stats = Instantiate(prefabPlayerStats, place.transform);
                    delete.Add(stats);

                    if (i < 19)
                    {
                        stats.transform.localPosition += new Vector3(0, -50 * i, 0);
                    }
                    else
                    {
                        stats.transform.localPosition += new Vector3(1100, -50 * (i-19), 0);
                    }
                    
                    stats.GetComponent<StatsOnScreen>().CheckStat(i, timeList[i], resultList[i],dayList[i],moneyList[i]);
                }
                
            }


        }
    }

    
}
