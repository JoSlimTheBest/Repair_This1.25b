using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StatsOnScreen : MonoBehaviour
{
    public TextMeshProUGUI number;
    public TextMeshProUGUI time;
    public TextMeshProUGUI end;
    public TextMeshProUGUI dayT;
    public TextMeshProUGUI moneyT;


    public void CheckStat(int numb,string timing, int ending,int day,int money)
    {
        number.text = numb.ToString();

       
        time.text = timing;
       
        if(ending == 0)
        {
            end.text = "����� �� ����";
            end.color = Color.red;
        }

        if(ending == 1)
        {
            end.text = "������ ������";
            end.color = Color.yellow;
        }

        if(ending == 2)
        {
            end.text = "������� ����";
            end.color = Color.blue;
        }
        if(ending == 3)
        {
            end.text = "�������";
            end.color = Color.green;
        }


        dayT.text = day.ToString();
        moneyT.text = money.ToString();

    }
}
