using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenMenuOpening : BaseScreen
{
    [SerializeField] private Vector2 offSet;
    [SerializeField] private Button startBtn;
    [SerializeField] private Button intructionsBtn;
    [SerializeField] private Button settingBtn;
    [SerializeField] private Button quitBtn;

  
    private void Start()
    {
        if(TryGetComponent<RectTransform>(out var rectTransform))
        {
            rectTransform.anchoredPosition = offSet;
        }
        InitListenerButton();
    }
    private void InitListenerButton()
    {
        intructionsBtn.onClick.AddListener(OnClickIntructionsButton);
        settingBtn.onClick.AddListener(OnClickSettingButton);
        quitBtn.onClick.AddListener(OnClickQuitButton);
    }
    private void OnClickSettingButton()
    {
        if (UIManager.HasInstance)
        {
            UIManager.Instance.ShowPopup<PopupSetting>();
        }
    }
    private void OnClickIntructionsButton()
    {
        if(UIManager.HasInstance)
        {
            UIManager.Instance.ShowPopup<PopupIntructions>();
        }
    }
    private void OnClickQuitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
