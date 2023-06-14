using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ComputerTime : MonoBehaviour
{

    public int currentDay = 1;
    public float minute =0;
    public int hours =10;

    public float speedTime = 4;
    public float slowSpeedTime = 1;

    public bool slowTime;
    public TextMeshProUGUI timeOncomputer;
    public TextMeshProUGUI timeOncomputer2;
    public TextMeshProUGUI dayOnScreen;


    public SpriteRenderer window;
    public float changeWindowDark;

    public float windowColorTime;

    public List<HumanCharacter> heroes = new List<HumanCharacter>();

    public Switcher sw;
    public BumBoxController bbControl;

    public bool gameStop = false;
    public bool alarmClock = false;

    public void Addheroes(GameObject her)
    {
        heroes.Add(her.GetComponent<HumanCharacter>());
    }
    
    public void ChangeTimeSlow(bool slowtiming)
    {
        if (hours >= 22)
        {
            slowTime = true;
            return;

        }

        slowTime = slowtiming;
    }
    
    public void DayComingWindow()
    {
        window.color = new Color(1, 1, 1, 1);
    }
    public void ChangeWindow()
    {
        windowColorTime = window.color.r;
        if (hours >4 && hours <16 && windowColorTime <1 )
        {

            window.color = new Color(window.color.r + changeWindowDark, window.color.g + changeWindowDark, window.color.b + changeWindowDark);
        }
        if (hours < 16)
        {
            return;
        }
        if(window.color.r >= 0.31f)
        {
            window.color = new Color(window.color.r - changeWindowDark, window.color.g - changeWindowDark, window.color.b - changeWindowDark);
        }
       


    }
    // Update is called once per frame
    void FixedUpdate()
    {

        if(gameStop == true)
        {
            return;
        }
        for(int i =0; i < heroes.Count; i++)
        {
            if(heroes[i].day == currentDay)
            {
                if (heroes[i].hour <= hours)
                {
                    if (heroes[i].minute <= minute)
                    {
                        GetComponent<HumanQueue>().HumanEventList(heroes[i].gameObject);
                        heroes.Remove(heroes[i]);
                    }
                }
            }
           
        }

        if (slowTime == true)
        {
            minute += slowSpeedTime * Time.deltaTime;
        }
        else
        {
            minute += speedTime * Time.deltaTime;
        }






        // changer
        if(minute >= 59.5)
        {
            hours += 1;
            minute = 0;
            GetComponent<ElectricBill>().AddDollarBill(0.2f);
            if (sw.change == true)
            {
                GetComponent<ElectricBill>().AddDollarBill(1);

            }

            if(bbControl.active == true)
            {
                GetComponent<ElectricBill>().AddDollarBill(1);
            }
            
        }

        if (hours >= 22)
        {
            if(alarmClock == false)
            {
                timeOncomputer2.GetComponent<AlarmClock>().AlarmActive();
                alarmClock = true;
            }
           
            slowTime = true;
            if (hours >= 24)
            {
                // GameObject.Find("RestartDaY").GetComponent<NewDay>().Task();
                hours = 0;
            }
           
        }
      

        string minute0;

        if(minute < 10)
        {
            int m = (int)minute;
            minute0 = "0" + m.ToString("0");
        }
        else
        {
            minute0 = minute.ToString("0");
        }

        timeOncomputer.text = hours.ToString() + ":" + minute0;
        timeOncomputer2.text = hours.ToString() + ":" + minute0;
        dayOnScreen.text = currentDay.ToString();
        ChangeWindow();


    }

  
}
