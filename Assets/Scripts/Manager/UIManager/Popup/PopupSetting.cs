using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupSetting : BasePopup
{
    [SerializeField] private Button exitButton;
    [SerializeField] private Toggle musicToggle;
    [SerializeField] private Toggle soundToggle;
    [SerializeField] private Slider soundSlider;
    [SerializeField] private Slider musicSlider;

    private void Start()
    {
        if (exitButton != null)
        {
            exitButton.onClick.AddListener(OnExitButtonClick);
        }
        InitToggleAndSlider();

    }
    private void InitToggleAndSlider()
    {
        musicToggle.onValueChanged.AddListener(OnClickMusicToggle);
        soundSlider.onValueChanged.AddListener(OnClickSoundSlider);
        soundToggle.onValueChanged.AddListener(OnClickSoundToggle);
        musicSlider.onValueChanged.AddListener(OnClickMusicSlider);

    }
    private void OnClickMusicToggle(bool isOn)
    {
        if(AudioManager.HasInstance)
        {
            SetToggleAndSlider(isOn,true, musicSlider);
            AudioManager.Instance.PlaySE("ClickButton");
        }
    }
    private void OnClickSoundToggle(bool isOn)
    {
        if (AudioManager.HasInstance)
        {
            SetToggleAndSlider(isOn,false, soundSlider);
            AudioManager.Instance.PlaySE("ClickButton");
        }
    }
    private void OnClickSoundSlider(float value)
    {
        if(AudioManager.HasInstance)
        {
            SetSlider(value, false, soundSlider);
            if(value == 0)
            {
                soundToggle.isOn = true;
            }
            else
            {
                soundToggle.isOn = false;
            }
        }
    }
    private void OnClickMusicSlider(float value)
    {
        if (AudioManager.HasInstance)
        {
            SetSlider(value, true, musicSlider);
            if(value == 0)
            {
                musicToggle.isOn = true;
            }
            else
            {
                musicToggle.isOn = false;
            }
        }
    }
    private void OnExitButtonClick()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE("ExitButton");
        }
        this.Hide();
    }   
    private void SetToggleAndSlider(bool isShow ,bool IsBGM,Slider slider)
    {
        if(IsBGM)
        {
            AudioManager.Instance.BGMAudio.volume = isShow ? 0 : 1;
            slider.value = AudioManager.Instance.BGMAudio.volume;
        }
        else
        {
            AudioManager.Instance.SEAudio.volume = isShow ? 0 : 1;
            slider.value = AudioManager.Instance.SEAudio.volume;
        }
        
    }
    private void SetSlider(float value ,bool isBGM, Slider slider)
    {
        if (slider != null)
        {
            if(isBGM)
            {
                AudioManager.Instance.BGMAudio.volume = value;
            }
            else
            {
                AudioManager.Instance.SEAudio.volume = value;
            }
        }
    }
    
   
}
