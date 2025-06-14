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

    private readonly Dictionary<string, AudioClip> bgmDitc = new();
    private readonly Dictionary<string, AudioClip> seDitc = new();
    private readonly string PATH_AUDIO_CLIP_BGM = "Audio/BGM";
    private readonly string PATH_AUDIO_CLIP_SE = "Audio/SE";





    private void Start()
    {
        //MenuGameMusic();
        LoadAllAudioClip(PATH_AUDIO_CLIP_BGM);
    }
    private void LoadAllAudioClip(string path)
    {
        foreach (var item in Resources.LoadAll<AudioClip>(path))
        {
            if (!bgmDitc.ContainsKey(item.name))
            {
                bgmDitc.Add(item.name, item);
            }
        }
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
