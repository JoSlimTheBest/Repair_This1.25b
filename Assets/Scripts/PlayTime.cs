using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayTime : MonoBehaviour
{
    private float timeSecond = 0; // ����� � ������ ������� � ��������
    private float timeMinute = 0;
    private float timeHours = 0;
    private TextMeshProUGUI liveTime;

    void Start()
    {
        liveTime = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeSecond += Time.deltaTime;

        if (timeSecond >= 60)
        {
            timeMinute += 1;
            timeSecond = 0;
        }
        if (timeMinute >= 60)
        {
            timeHours += 1;
            timeMinute = 0;
        }
        // Debug.Log(timeHours + ":" + timeMinute + ":" + timeSecond);
        liveTime.text = timeHours.ToString("0.") + ":" + timeMinute.ToString("0.") + ":" + timeSecond.ToString("0.");
    }
}
