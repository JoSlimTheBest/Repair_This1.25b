using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyOnDisplay : MonoBehaviour
{
    public PlayerCharacter player;
    public void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerCharacter>();
    }

    void FixedUpdate()
    {
        GetComponent<TextMeshProUGUI>().text = player.money.ToString();
    }
}
