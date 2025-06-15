using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class AudioManager : BaseManager<AudioManager>
{
    [ShowInInspector]
    private Dictionary<string, AudioClip> bgmDitc = new();
    [ShowInInspector]
    private Dictionary<string, AudioClip> seDitc = new();

    public AudioSource BGMAudio;
    public AudioSource SEAudio;
    public AudioClip menuGameMusic;
    public AudioClip playGameMusic;
    public AudioClip nextLevel;
    public AudioClip CombatMusic;
    
    private readonly string PATH_AUDIO_CLIP_BGM = "Audio/BGM";
    private readonly string PATH_AUDIO_CLIP_SE = "Audio/SE";

    private void Start()
    {
        //MenuGameMusic();
        LoadAllAudioClip(PATH_AUDIO_CLIP_BGM,bgmDitc);
        LoadAllAudioClip(PATH_AUDIO_CLIP_SE,seDitc);
    }
    private void LoadAllAudioClip(string path, Dictionary<string, AudioClip> diction)
    {
        foreach (var item in Resources.LoadAll<AudioClip>(path))
        {
            if (!diction.ContainsKey(item.name))
            {
                diction.Add(item.name, item);
            }
        }
    }
    public void PlaySE(string nameSound)
    {
        if(seDitc.ContainsKey(nameSound))
        {
            SEAudio.PlayOneShot(seDitc[nameSound]);
        }
       
    }  
    public void PlayBGM(string nameSound)
    {
        if (bgmDitc.ContainsKey(nameSound))
        {
            if (BGMAudio.isPlaying)
            {
                BGMAudio.Stop();
            }
            BGMAudio.clip = bgmDitc[nameSound];
            BGMAudio.Play();
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
