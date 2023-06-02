using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autors : MonoBehaviour
{
    public List<string> nameAutors = new List<string>();

    public List<Sprite> pictureAutors = new List<Sprite>();

    public GameObject autorPrefab;

    public float liveTimeAutor;
    private float createNew = 5;
    public void CreateAutor()
    {
        GameObject a = Instantiate(autorPrefab);
        Destroy(a, liveTimeAutor);
    }


    public void FixedUpdate()
    {
        if(createNew > 0)
        {
            createNew -= Time.deltaTime;
            if(createNew <= 0)
            {
                CreateAutor();
                createNew = 5;
            }
        }
    }
}
