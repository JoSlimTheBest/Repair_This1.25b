using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafeBoxChangeImage : MonoBehaviour
{
    public Sprite open;
    public Sprite close;
    private AudioSource source;
    public AudioClip openA;
    public AudioClip closeA;

    public GameObject moneySafeScreen;

    public void Start()
    {
       source = GameObject.Find("AudioEvent").GetComponent<AudioSource>();
    }
    public void Changer()
    {
        GetComponent<SpriteRenderer>().sprite = open;
        Invoke("ComeBack", 0.6f);
        source.PlayOneShot(openA);
        moneySafeScreen.SetActive(false);
    }

    private void ComeBack()
    {
        GetComponent<SpriteRenderer>().sprite = close;
        source.PlayOneShot(closeA);
        moneySafeScreen.SetActive(true);
    }
}
