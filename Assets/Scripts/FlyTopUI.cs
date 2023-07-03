using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlyTopUI : MonoBehaviour
{
    private TextMeshProUGUI text;
    public float goTop = 0.01f;
    public float loseColor = 0.01f;
    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
    }


    public void GiveColor()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
    }
    private void FixedUpdate()
    {
        transform.localPosition += new Vector3(0, goTop, 0);
        text.color += new Color(0, 0, 0, -loseColor);
    }
}
