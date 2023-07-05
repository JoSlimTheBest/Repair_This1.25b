using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsChanger : MonoBehaviour
{
    public List<GameObject> listNews = new List<GameObject>();
    public GameObject currentNews;


    public void Start()
    {
        ChangeNews();
    }
    public void ChangeNews()
    {
        if (listNews.Count == 0) { return; }
        if (currentNews != null)
        {
            Destroy(currentNews);
        }
     
        int n = Random.Range(0, listNews.Count);
        GameObject createNews = Instantiate(listNews[n], transform);
        listNews.Remove(listNews[n]);

        currentNews = createNews;
    }
}
