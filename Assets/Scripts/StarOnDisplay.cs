using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StarOnDisplay : MonoBehaviour
{
    public PlayerCharacter player;
    public List<Image> stars = new List<Image>();
    public Color yellowStar;
    
    
    public void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerCharacter>();
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<Image>() != null)
            {
                stars.Add(transform.GetChild(i).GetComponent<Image>());
            }
        }
        checkStar();
    }


    public void checkStar()
    {
       float raitStar = player.raiting;
        for(int i = 0; i < stars.Count; i++)
        {
            if(i+1 <= Mathf.Round(raitStar))
            {
                stars[i].color = yellowStar;
            }
            else
            {
                stars[i].color = new Color(1, 1, 1, 1);
            }
            
        }
    }

    void FixedUpdate()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = player.raiting.ToString("0.0");
        checkStar();
    }
}
