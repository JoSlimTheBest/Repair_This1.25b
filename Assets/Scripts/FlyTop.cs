using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlyTop : MonoBehaviour
{
    private TextMeshPro text;
    public float goTop = 0.01f;
    public float loseColor = 0.01f;
    private void Start()
    {
        text = GetComponent<TextMeshPro>();
    }
    private void FixedUpdate()
    {
        transform.position += new Vector3(0, goTop, 0);
        text.color += new Color(0, 0, 0, -loseColor);
    }
}
