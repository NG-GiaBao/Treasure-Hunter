using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : BaseManager<AudioManager>
{

    public AudioSource BGMAudio;
    public AudioSource SEAudio;
    public AudioClip menuGameMusic;
    public AudioClip playGameMusic;
    public AudioClip nextLevel;
    public AudioClip CombatMusic;

    public static AudioManager instance;


    private void Start()
    {
        MenuGameMusic();
    }
    public void PlaySoundEffect(AudioClip audioClip)
    {
        SEAudio.PlayOneShot(audioClip);
    }

    public void PlayBackGroundMusic(AudioClip audioClip)
    {
        if (BGMAudio.isPlaying)
        {
            BGMAudio.Stop();
            BGMAudio.clip = audioClip;
            BGMAudio.Play();
        }
        else
        {
            BGMAudio.clip = audioClip;
            BGMAudio.Play();
        }
    }

    public void MenuGameMusic()
    {
        PlayBackGroundMusic(menuGameMusic);
    }

    public void PlayGameMusic()
    {
        PlayBackGroundMusic(playGameMusic);
    }
    public void NextGameMusic()
    {
        PlayBackGroundMusic(nextLevel);
    }

    public void MusicCombat()
    {
        PlayBackGroundMusic(CombatMusic);
    }
}
