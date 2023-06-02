using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StockPhonePart : MonoBehaviour
{
    public List<int> partCount = new List<int>();
    public List<TextMeshProUGUI> textPart = new List<TextMeshProUGUI>();
    
    
    public int countPart = 6;
    public GameObject prefabText;
    public string model;
    public void Awake()
    {
        for(int i = 0; i < countPart; i++)
        {
            GameObject _part = Instantiate(prefabText, transform);
            _part.transform.localPosition = new Vector3(0, -100 * (i+1));
            textPart.Add(_part.GetComponent<TextMeshProUGUI>());

            partCount.Add(0);  //load!
            textPart[i].text = partCount[i].ToString();
        }
    }
    private void FixedUpdate()
    {
        for(int i = 0; i < textPart.Count; i++)
        {
            textPart[i].text = partCount[i].ToString();
            
        }
    }

    public void AddPart(int part, int count)
    {
        partCount[part] += count;
        textPart[part].text = partCount[part].ToString();
    }
    public void TakePart(int part)
    {
        partCount[part] -= 1;
    }




}
