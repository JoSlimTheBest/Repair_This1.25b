using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using SimpleLocalizator;
public class StoryTaller : MonoBehaviour
{

    public List<Sprite> spriteStory = new List<Sprite>();
    public int currentStory = 0;
    private Image storyHolder;
    private GameObject button;
    public Sprite preLast;
    public Sprite last;
    public GameObject load;
    public List<string> rusHold = new List<string>();
    public List<string> engHold = new List<string>();
    public TextMeshProUGUI text;

    private AudioSource audioS;
    public AudioClip useKey;
    public float nextwindow = 12;
    public int whatThScene = 2;
    private bool corActvie;

    private string dataText;
 
    public void Start()
    {
        storyHolder = GetComponent<Image>();
        button = GetComponentInChildren<Button>().gameObject;
        audioS = GetComponent<AudioSource>();
        TextEvent();
    }
    public void NextStory()
    {
        if(corActvie == true)
        {
            StopAllCoroutines();
            text.text = dataText;
            corActvie = false;
            return;
        }


        nextwindow = 12;
       
        text.text = " ";
        if(currentStory < spriteStory.Count)
        {
            storyHolder.sprite = spriteStory[currentStory];
            currentStory += 1;
            TextEvent();
        }
        else
        {
            Destroy(button);
            load.SetActive(true);
            storyHolder.sprite = preLast;
            Invoke("LoadNextSce", 0.3f);
        }
    }

    private void LoadNextSce()
    {
        storyHolder.sprite = last;
        SceneManager.LoadScene(whatThScene);
    }


    IEnumerator showText(string tet)
    {
        corActvie = true;
        int i = 0;
        while (i <= tet.Length)
        {
            text.text = tet.Substring(0, i);
            i++;
            audioS.PlayOneShot(useKey);
            yield return new WaitForSeconds(0.05f);
        }
        corActvie = false;
    }

    public void TextEvent()
    {
        
        if (LanguageManager.currentLang == Language.English)
        {
            dataText = engHold[currentStory];
        }
        else
        {
            dataText = rusHold[currentStory];
        }

        StartCoroutine("showText", dataText);
    }


    private void FixedUpdate()
    {
        nextwindow -= 1f * Time.deltaTime;

        if(nextwindow < 0)
        {
            NextStory();
        }
    }
}
