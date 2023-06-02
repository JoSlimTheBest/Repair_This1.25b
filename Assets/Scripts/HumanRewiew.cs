using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SimpleLocalizator;

public class HumanRewiew : MonoBehaviour
{
    public int star;
    public GameObject starPrefab;
    public GameObject starHolder;
    public TextMeshProUGUI currentText;

    public Image imagePeople;
    public Sprite face;



    public List<string> oneStar = new List<string>();
    public List<string> twoStar = new List<string>();
    public List<string> threeStar = new List<string>();
    public List<string> fourStar = new List<string>();
    public List<string> fiveStar = new List<string>();

    public List<string> oneStarEng = new List<string>();
    public List<string> twoStarEng= new List<string>();
    public List<string> threeStarEng = new List<string>();
    public List<string> fourStarEng = new List<string>();
    public List<string> fiveStarEng = new List<string>();


    


    private void Awake()
    {
        if (face != null)
        {
            Debug.Log("Take picture");
        }
        else
        {
            Debug.Log("No picture");
        }
    }

    public void Start()
    {

        imagePeople.sprite = face;
        for (int i = 0; i < star; i++)
        {
           GameObject currentStar = Instantiate(starPrefab, starHolder.transform);
            currentStar.transform.localPosition += new Vector3(0 + 50 * i, 0);
        }
        if(currentText.text.Length > 2)
        {
            return;
        }

        if(LanguageManager.currentLang == Language.English)
        {
            if(star == 1)
            {
                currentText.text = oneStarEng[Random.Range(0, oneStarEng.Count)];
                return;
            }
            if(star == 2)
            {
                currentText.text = twoStarEng[Random.Range(0, twoStarEng.Count)];
                return;
            }
            if (star == 3)
            {
                currentText.text = threeStarEng[Random.Range(0, threeStarEng.Count)];
                return;
            }
            if (star == 4)
            {
                currentText.text = fourStarEng[Random.Range(0, fourStarEng.Count)];
                return;
            }
            if (star == 5)
            {
                currentText.text = fiveStarEng[Random.Range(0, fiveStarEng.Count)];
            }
        }
        else
        {
            if (star == 1)
            {
                currentText.text = oneStar[Random.Range(0, oneStar.Count)];
                return;
            }
            if (star == 2)
            {
                currentText.text = twoStar[Random.Range(0, twoStar.Count)];
                return;
            }
            if (star == 3)
            {
                currentText.text = threeStar[Random.Range(0, threeStar.Count)];
                return;
            }
            if (star == 4)
            {
                currentText.text = fourStar[Random.Range(0, fourStar.Count)];
                return;
            }
            if (star == 5)
            {
                currentText.text = fiveStar[Random.Range(0, fiveStar.Count)];
            }
        }


       
    }
}
