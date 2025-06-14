using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoverSound : MonoBehaviour , IPointerEnterHandler
{
    [SerializeField] private AudioClip m_ButtonHightlightSound;

    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioManager.Instance.PlaySoundEffect(m_ButtonHightlightSound);
    }
}
