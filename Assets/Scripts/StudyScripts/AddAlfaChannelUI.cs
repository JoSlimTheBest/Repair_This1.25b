using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddAlfaChannelUI : MonoBehaviour
{
    public float loseColor = 0.01f;
    public Color alphaStart;
    public void Start()
    {
        AlphaRestart();
    }
    
    public void AlphaRestart()
    {
        GetComponent<Image>().color = alphaStart;
    }

    public void FixedUpdate()
    {
        GetComponent<Image>().color -= new Color(0, 0, 0, loseColor);
    }
}
