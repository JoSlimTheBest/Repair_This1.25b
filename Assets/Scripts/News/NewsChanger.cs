using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsChanger : MonoBehaviour
{
    public List<GameObject> listNews = new List<GameObject>();
    public GameObject currentNews;
    public GameObject nextNews;
    public GameObject bg;


    public void Awake()
    {
        ChangeNews();
        bg.SetActive(false);
    }
    public void ChangeNews()
    {
        GameObject createNews;


        if (currentNews != null)
        {
            Destroy(currentNews);
        }

        if(nextNews != null)
        {
            Debug.Log("ChangeNewsDay");
            createNews = Instantiate(nextNews, transform);
            nextNews = null;
            
        }
        else
        {
            if (listNews.Count == 0) { return; }
            int n = Random.Range(0, listNews.Count);
            createNews = Instantiate(listNews[n], transform);
            listNews.Remove(listNews[n]);
        }


       
        

        currentNews = createNews;
    }

    public void NextNewsAdd(GameObject news)
    {
        nextNews = news;
        Debug.Log("AddNeWS");
    }
}
