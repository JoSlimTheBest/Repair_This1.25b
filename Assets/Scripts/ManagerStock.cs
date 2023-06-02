using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerStock : MonoBehaviour
{
    public StockPhonePart modelA;
    public StockPhonePart modelM;
    public StockPhonePart modelS;
    public MessageHolder mess;


    public BuyPhonePart modelABuy;
    public BuyPhonePart modelMBuy;
    public BuyPhonePart modelSBuy;

    public GameObject CheckFiles;

    private void Awake()
    {
        modelA = GameObject.Find("ModelA").GetComponent<StockPhonePart>();
        modelM = GameObject.Find("ModelM").GetComponent<StockPhonePart>();
        modelS = GameObject.Find("ModelS").GetComponent<StockPhonePart>();

    }

    public void AddPart(string model,int part, int count)
    {
        if(model == "A")
        {
            modelA.AddPart(part, count);
        }
        if (model == "M")
        {
            modelM.AddPart(part, count);
        }
        if (model == "S")
        {
            modelS.AddPart(part, count);
        }
    }

    public bool CheckPart(string model, int part)
    {
        if (model == "A")
        {
            if (modelA.partCount[part] > 0)
            {
                return true;
            }
        }
        if (model == "M")
        {
            if (modelM.partCount[part] > 0)
            {
                return true;
            }
        }
        if (model == "S")
        {
            if (modelS.partCount[part] > 0)
            {
                return true;
            }
        }

        return false;
    }

    public int CheckCost(string model,int part)
    {

        int costReal=0;

        if (model == "A")
        {
            
            costReal = modelABuy.costEasyBuy[part];
            return costReal;
        }
        if (model == "M")
        {
            
            costReal = modelMBuy.costEasyBuy[part];
            return costReal;
        }
        if (model == "S")
        {
            costReal = modelSBuy.costEasyBuy[part];
            return costReal;
        }


        return costReal;
    }
}
