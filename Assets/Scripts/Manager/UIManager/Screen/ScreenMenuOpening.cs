using EasyTransition;
using UnityEngine;
using UnityEngine.UI;

public class ScreenMenuOpening : BaseScreen
{
    [SerializeField] private Vector2 offSet;
    [SerializeField] private Button startBtn;
    [SerializeField] private Button intructionsBtn;
    [SerializeField] private Button settingBtn;
    [SerializeField] private Button quitBtn;
    [SerializeField] private string nameScene;

  
    private void Start()
    {
        if(TryGetComponent<RectTransform>(out var rectTransform))
        {
            rectTransform.anchoredPosition = offSet;
        }
        InitListenerButton();
    }
    private void OnDestroy()
    {
        TransitionManager.Instance().onTransitionEnd -= ShowImformationPlayer;
    }
    private void InitListenerButton()
    {
        startBtn.onClick.AddListener(OnClickStartButton);
        intructionsBtn.onClick.AddListener(OnClickIntructionsButton);
        settingBtn.onClick.AddListener(OnClickSettingButton);
        quitBtn.onClick.AddListener(OnClickQuitButton);
    }
    private void OnClickStartButton()
    {
        if (HandlerTransitionManager.HasInstance)
        {
            HandlerTransitionManager.Instance.LoadScene(nameScene);
        }

        if (GameManager.HasInstance)
        {
            GameManager.Instance.SetMap(GameMap.Lv1);
        }
        SoundClickButton();
        TransitionManager.Instance().onTransitionEnd += ShowImformationPlayer;
        Invoke(nameof(this.Hide), 1f);
    }    
    private void ShowImformationPlayer()
    {
        if (UIManager.HasInstance)
        {
            UIManager.Instance.ShowScreen<ScreenHealBarPlayer>();
        }
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlayBGM("Happy");
        }
        SoundClickButton();
    }
    private void OnClickSettingButton()
    {
        if (UIManager.HasInstance)
        {
            UIManager.Instance.ShowPopup<PopupSetting>();
        }
        SoundClickButton();
    }
    private void OnClickIntructionsButton()
    {
        if(UIManager.HasInstance)
        {

            UIManager.Instance.ShowPopup<PopupIntructions>();
        }
        SoundClickButton();
    }
    private void SoundClickButton()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE("ClickButton");
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
