using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumBoxController : MonoBehaviour
{
    public List<AudioClip> musicTrack = new List<AudioClip>();
    private AudioSource music;
    private Animator anim;
    public bool active=true;
    void Start()
    {
        anim = GetComponent<Animator>();
        music = GetComponent<AudioSource>();
        music.clip = musicTrack[Random.Range(0, musicTrack.Count)];
        music.Play();
    }

    public void StopStartMusic()
    {
        if(active == true)
        {
            anim.SetBool("Active", false);
            music.Stop();
            active = false;
        }
        else
        {
            anim.SetBool("Active", true);
            music.clip = musicTrack[Random.Range(0, musicTrack.Count)];
            music.Play();
            active = true;
        }
    }
    private void FixedUpdate()
    {
        if (music.isPlaying == false && active == true)
        {
            music.clip = musicTrack[Random.Range(0, musicTrack.Count)];
            music.Play();
        }
    }


}
