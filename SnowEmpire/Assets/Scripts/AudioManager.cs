using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] AudioSource snow, growl, music, battlemusic, click;

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

    public void PlayBattleMusic()
    {
        battlemusic.Play();
    }

    public void StopBattleMusic()
    {
        battlemusic.Pause();
    }

    public void PlayClickSound()
    {
        click.Play();
    }
}
