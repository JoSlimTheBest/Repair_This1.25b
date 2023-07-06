using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHumanTime : MonoBehaviour
{
    public int day = 0;
    public int addHour = 0;
    public void AddTimeHuman()
    {
       GetComponent<HumanCharacter>().day += day;
       GetComponent<HumanCharacter>().hour += addHour;
    }
}
