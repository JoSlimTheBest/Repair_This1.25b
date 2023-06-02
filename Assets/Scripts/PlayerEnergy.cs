using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerEnergy : MonoBehaviour
{
    public int playerEnergy;
    public Slider slider;
    public TextMeshProUGUI textsl;

    private void Start()
    {
        slider.value = playerEnergy;
        textsl.text = playerEnergy.ToString() + "%";
    }


    public void AddEnergy(int energy)
    {
        playerEnergy += energy;
        if(playerEnergy < 0)
        {
            playerEnergy = 0;
        }
        if(playerEnergy > 100)
        {
            playerEnergy = 100;
        }

        slider.value = playerEnergy;
        textsl.text = playerEnergy.ToString() + "%";
    }
}
