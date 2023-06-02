using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTimePlayer : MonoBehaviour
{
    public int timeButton;
    public CostChangerCharacter costChanger;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(GoTime);
    }

  

    public void GoTime()
    {
        costChanger.SetTime(timeButton);
    }
}
