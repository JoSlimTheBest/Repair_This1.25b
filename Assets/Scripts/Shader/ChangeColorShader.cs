using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColorShader : MonoBehaviour
{
    public float width;
    void Start()
    {
        GetComponent<SpriteRenderer>().material.SetFloat("_OutlineWidth", width);
        
        
    }

    
}
