using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UISound : MonoBehaviour
{
    
    [SerializeField] private AudioClip m_ButtonClickSound;
   

    
    public void PlayButtonClickSound()
    {
        AudioManager.Instance.PlaySoundEffect(m_ButtonClickSound);
    }
}
