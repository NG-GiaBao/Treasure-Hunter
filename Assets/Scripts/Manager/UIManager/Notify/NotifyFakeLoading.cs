using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotifyFakeLoading : BaseNotify
{
    [SerializeField] private Slider progressSlider;
    [SerializeField] private Animator cannonAnimator;
    [SerializeField] private TextMeshProUGUI progressTxt;
    private readonly int nameClipStringToHash = Animator.StringToHash("CannonFireUi");

    private void Start()
    {
        cannonAnimator.Play(nameClipStringToHash);
        progressSlider.value = 0f;
        LoadProgress();
    }

    private void LoadProgress()
    {
        progressSlider.DOValue(progressSlider.maxValue,3f).SetEase(Ease.Linear).OnUpdate(() =>
        {
            progressTxt.text = $"LOADING...{Mathf.RoundToInt(progressSlider.value * 100)}%";
        }).OnComplete(() =>
        {
            if(AudioManager.HasInstance)
            {
                AudioManager.Instance.MenuGameMusic();
            }
           
            HideCanvasGroup();
        });
    }    
    private void HideCanvasGroup()
    {
        canvasGroup.DOFade(0f, 1f).OnComplete(() =>
        {
            Hide();
        });
    }    


}
