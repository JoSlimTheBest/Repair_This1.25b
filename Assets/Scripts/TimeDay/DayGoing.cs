using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayGoing : MonoBehaviour
{
    public List<string> weekEng = new List<string>();
    public List<string> weekRus = new List<string>();

    private void Start()
    {
        weekEng.Add("Monday");
        weekEng.Add("Tuesday");
        weekEng.Add("Wednesday");
        weekEng.Add("Thursday");
        weekEng.Add("Friday");
        weekEng.Add("Saturday");
        weekEng.Add("Sunday");


        weekRus.Add("�����������");
        weekRus.Add("�������");
        weekRus.Add("�����");
        weekRus.Add("�������");
        weekRus.Add("�������");
        weekRus.Add("�������");
        weekRus.Add("�����������");

    }
}
