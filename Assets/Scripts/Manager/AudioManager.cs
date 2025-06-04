using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] private AudioSource backGroundaudioSource;
    [SerializeField] private AudioSource EffectAudioSource;
    public AudioClip menuGameMusic;
    public AudioClip playGameMusic;
    public AudioClip nextLevel;
    public AudioClip CombatMusic;

    public static AudioManager instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {

        MenuGameMusic();
    }
    private void Update()
    {
        
    }
    public void PlaySoundEffect(AudioClip audioClip)
    {
        EffectAudioSource.PlayOneShot(audioClip);
    }

    public void PlayBackGroundMusic(AudioClip audioClip)
    {
        if (backGroundaudioSource.isPlaying)
        {
           backGroundaudioSource.Stop();
           backGroundaudioSource.clip = audioClip;
           backGroundaudioSource.Play();
        }
        else
        {
            backGroundaudioSource.clip = audioClip;
            backGroundaudioSource.Play();
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
