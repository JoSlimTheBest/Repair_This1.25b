using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogRotate : MonoBehaviour
{
    public float loseColor = 0.01f;
    public float randomRotate = 1;
    
    public int energyTake = -2;
    public float fullColorTime = 2;

    private void Start()
    {
        GameObject.Find("Player").GetComponent<PlayerEnergy>().AddEnergy(energyTake);
    }

    public void AddColor()
    {

    }
    void FixedUpdate()
    {
       
        transform.Rotate(0, 0, Random.Range(-randomRotate, randomRotate));
        if (fullColorTime > 0)
        {
            fullColorTime -= Time.deltaTime;
            return;
        }
        GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, loseColor);
       
        GetComponentInChildren<TextMeshPro>().color -= new Color(0, 0, 0, loseColor);
       
        
    }
}
