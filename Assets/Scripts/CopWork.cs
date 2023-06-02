using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SimpleLocalizator;
using UnityEngine.SceneManagement;

public class CopWork : MonoBehaviour
{

    public List<string> sayEng = new List<string>();

    public List<string> sayRus = new List<string>();
    public float timing = 3;
    private float timingActive;

    public GameObject changer;
    public GameObject dialogprefab;
    public List<GameObject> enterDialog = new List<GameObject>();
    private int countDialog;
    private AudioSource audioS;
    public AudioClip saySome;
    public float topperDialog = 150;

    public void Start()
    {
        GameObject.Find("door").GetComponent<DoorController>().DoorEvent();
        audioS = GameObject.Find("AudioEvent").GetComponent<AudioSource>();
        timingActive = timing;
    }

    public void SaySome()
    {

        if(countDialog >= sayRus.Count)
        {
            LoadFinalScene();
            return;
        }
        GameObject currentDialog = Instantiate(dialogprefab, transform.position, transform.rotation, changer.transform);
        currentDialog.transform.localPosition += new Vector3(2.8f, 0f);
        currentDialog.transform.Rotate(0, 0, Random.Range(-2, 3));
        Destroy(currentDialog, 5);
        if (LanguageManager.currentLang == Language.English)
        {
            currentDialog.GetComponentInChildren<Transform>().GetComponentInChildren<TextMeshPro>().text = sayEng[countDialog];
        }
        else
        {
            currentDialog.GetComponentInChildren<Transform>().GetComponentInChildren<TextMeshPro>().text = sayRus[countDialog];
        }

        countDialog += 1;

        enterDialog.Add(currentDialog);
        for (int i = 0; i < enterDialog.Count; i++)
        {
            if (enterDialog[i] == null)
            {
                enterDialog.Remove(enterDialog[i]);
            }




        }

        for (int i = 0; i < enterDialog.Count; i++)
        {
            if (enterDialog[i] != null)
                enterDialog[i].transform.localPosition += new Vector3(0, topperDialog);

        }

        audioS.PlayOneShot(saySome);
    }


    public void LoadFinalScene()
    {
        SceneManager.LoadScene(4);
    }

    private void FixedUpdate()
    {
        if(timingActive < 0)
        {
            SaySome();
            timingActive = timing;
        }
        else
        {
            timingActive -= Time.deltaTime;
        }
    }
}
