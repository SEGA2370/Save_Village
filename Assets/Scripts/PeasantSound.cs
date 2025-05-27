using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeasantSound : MonoBehaviour
{
    public static PeasantSound SndMan;

    private AudioSource audioSrc;

    private AudioClip[] buttonsSounds;

    private int randomButtonSound;

    // Start is called before the first frame update
    void Start()
    {
        SndMan = this;
        audioSrc = GetComponent<AudioSource>();
        buttonsSounds = Resources.LoadAll<AudioClip>("UnitSounds");
    }

    public void PlayButtonSound()
    {
        if (!audioSrc.isPlaying)
        {
            randomButtonSound = Random.Range(0, 5);
            audioSrc.PlayOneShot(buttonsSounds[randomButtonSound]);
        }
    }

    
}
