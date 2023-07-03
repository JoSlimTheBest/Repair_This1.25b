using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListPartCheck : MonoBehaviour
{
    public List<PartInStockCheck> checker = new List<PartInStockCheck>();


    public void Checker()
    {
        for(int i = 0; i < checker.Count; i++)
        {
            checker[i].CheckPart();
        }
    }
}
