using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewiewHolder : MonoBehaviour
{
    public GameObject prefabHumanRewiew;
    public GameObject prefabStar;

    public int countRewiew;


    public GameObject starHolder;
    public List<GameObject> rewiews = new List<GameObject>();
    


    public void AddRewiew(int countStar, string disctiptionR,Sprite human)
    {
        Debug.Log(disctiptionR + " "+ disctiptionR.Length);

        
       
        GameObject currentR =Instantiate(prefabHumanRewiew, transform);
        currentR.GetComponent<HumanRewiew>().star = countStar;
        currentR.GetComponent<HumanRewiew>().face = human;
        if (disctiptionR.Length >2)
        {
            currentR.GetComponent<HumanRewiew>().currentText.text = disctiptionR;
        }
        else
        {
            
        }
        rewiews.Add(currentR);


        countRewiew = rewiews.Count - 1;
        ShowRewiew(1);

    }

    public void ShowRewiew(int next)
    {
        if(rewiews.Count <= 0)
        {
            return;
        }
        Debug.Log(countRewiew);
       
        countRewiew += next;
        if(countRewiew < 0)
        {
            countRewiew = 0;
        }

        if (countRewiew > rewiews.Count - 1)
        {
            countRewiew = rewiews.Count - 1;
        }

            for(int i = 0; i<rewiews.Count; i++)
            {
                if(i == countRewiew)
                {
                    rewiews[i].transform.localPosition = new Vector3(0, 0, 0);
                }
                else
                {
                    rewiews[i].transform.localPosition = new Vector3(0, 1200, 0);
                }
                
            }

       
    }

}
