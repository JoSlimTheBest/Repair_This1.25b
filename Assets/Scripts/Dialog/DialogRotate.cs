using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogRotate : MonoBehaviour
{
    public float loseColor = 0.01f;
    public float randomRotate = 1;
    public float offer = 1;
    public int energyTake = -2;


    private void Start()
    {
        GameObject.Find("Player").GetComponent<PlayerEnergy>().AddEnergy(energyTake);
    }
    void FixedUpdate()
    {
        transform.Rotate(0, 0, Random.Range(-randomRotate, randomRotate));
        GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, loseColor);
        offer -= 1 * Time.deltaTime;
        if (offer <= 0)
        {
            GetComponentInChildren<TextMeshPro>().color -= new Color(0, 0, 0, loseColor);
        }
        
    }
}
