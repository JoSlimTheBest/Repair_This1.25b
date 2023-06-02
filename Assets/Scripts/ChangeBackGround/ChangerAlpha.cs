using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangerAlpha : MonoBehaviour
{
    private SpriteRenderer sprite;

    public Slider slider;
    public TextMeshProUGUI text;



    public void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
   
    public void FixedUpdate()
    {
        
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, slider.value);
        text.text = gameObject.name+ " ! " + slider.value.ToString();
    }

    public void AlphaChanger(float count)
    {
        slider.value = count;
    }
}
