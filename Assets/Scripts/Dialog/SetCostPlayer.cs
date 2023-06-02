using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetCostPlayer : MonoBehaviour
{
    public int costButton;
    public CostChangerCharacter costChanger; 

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(GoCost);
    }

    public void GetCost(int currentCost,CostChangerCharacter currentCostChanger)
    {
        costChanger = currentCostChanger;
        costButton = currentCost;
        GetComponentInChildren<TextMeshProUGUI>().text = currentCost.ToString();
    }

    public void GoCost()
    {
        costChanger.SetCost(costButton);
    }
}
