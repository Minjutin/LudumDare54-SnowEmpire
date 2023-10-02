using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] AudioSource snow, growl, music;

    public void PlaySnow()
    {
        snow.Play();
    }

    public void PlayGrowl()
    {
        growl.Play();
    }

    public void StopMusic()
    {
        music.Pause();
    }
}
