using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    private AudioSource source;
    private float musicVolume = 1f;
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        source.volume = musicVolume;
    }
    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
    public void Resolution1920per1080()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    public void Resolution800per600()
    {
        Screen.SetResolution(800, 600, true);
    }
}
