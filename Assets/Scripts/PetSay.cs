using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SimpleLocalizator;

public class PetSay : MonoBehaviour
{
    public GameObject dialogprefab;
    private float saysome;
    public void Gav()
    {
        if (GetComponent<SpriteRenderer>().flipX == false) { GetComponent<SpriteRenderer>().flipX = true; } else { GetComponent<SpriteRenderer>().flipX = false; }

        GameObject currentDialog = Instantiate(dialogprefab, transform.position, transform.rotation, transform);
        currentDialog.transform.localPosition += new Vector3(2f, 1f);
        currentDialog.transform.Rotate(0, 0, Random.Range(-2, 3));
        currentDialog.transform.localScale = new Vector3(0.4f, 0.4f, 1);
        if (LanguageManager.currentLang == Language.English)
        {
            currentDialog.GetComponentInChildren<Transform>().GetComponentInChildren<TextMeshPro>().text = "Woof Woof";
        }
        else
        {
            currentDialog.GetComponentInChildren<Transform>().GetComponentInChildren<TextMeshPro>().text = "√‡‚ √‡‚ ";
        }
        Destroy(currentDialog, 5);
    }


    private void FixedUpdate()
    {
        if(saysome < 0)
        {
            saysome = 8;
            Gav();
        }
        else
        {
            saysome -= Time.deltaTime;
        }
    }
}
