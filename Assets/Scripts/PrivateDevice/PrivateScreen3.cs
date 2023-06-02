using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SimpleLocalizator;

public class PrivateScreen3 : MonoBehaviour
{

    public GameObject space3;

    public Image curPhoto;
    public TextMeshProUGUI textPrivate;
    public GameObject copy;
    public void Start()
    {
        
    }


    public void CloseAll()
    {
        space3.SetActive(false);
        curPhoto.sprite = null;
        curPhoto.color = new Color(1, 1, 1, 0);
        textPrivate.text = " ";
        copy.SetActive(false);
    }

    public void OpenDiscription(string textNew, Sprite spriteNew)
    {
        space3.SetActive(true);
        if(spriteNew == null)
        {
            curPhoto.color = new Color(1, 1, 1, 0);
        }
        else
        {
            curPhoto.sprite = spriteNew;
            curPhoto.color = new Color(1, 1, 1, 1);
        }


        if (textNew == null)
        {
            textPrivate.text = " ";
        }
        else
        {
            textPrivate.text = textNew;
        }
        
    }


    public void OpenCopy(string pass)
    {
        copy.SetActive(true);
        copy.GetComponent<PrivatePasswordGo>().currentPassword = pass;
    }

    public void CloseCopy()
    {
        copy.SetActive(false);
        
    }
}
