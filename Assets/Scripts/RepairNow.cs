using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairNow : MonoBehaviour
{
    public int repairEnergyTake = -5;
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(Task);
    }

    private void Task()
    {
        GameObject.Find("Player").GetComponent<PlayerEnergy>().AddEnergy(repairEnergyTake);
        GetComponentInParent<RectTransform>().GetComponentInParent<PhoneRepairDiscription>().RepairIt();
        RepairList refresh = GameObject.Find("RepairList").GetComponent<RepairList>();
        refresh.CloseTable();
        refresh.CheckRepairPhone();
    }
}
