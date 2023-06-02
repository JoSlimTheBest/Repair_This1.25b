using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AudioButton : MonoBehaviour
{
    public AudioClip clip;
    private AudioSource ev;    
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(AudioGo);
        ev = GameObject.Find("AudioEvent").GetComponent<AudioSource>();
    }

   private void AudioGo()
    {
        ev.PlayOneShot(clip);
    }
}
