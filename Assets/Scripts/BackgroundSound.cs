using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSound : MonoBehaviour
{

    private new AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.Play();
    }

    public void ChangeSoundPlay() 
    {
        if (audio.isPlaying)
            audio.Pause();
        else
            audio.Play();
    }
}
