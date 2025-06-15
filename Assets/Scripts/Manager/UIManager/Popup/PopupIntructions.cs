using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupIntructions : BasePopup
{
    [SerializeField] private Button exitButton;
    private void Start()
    {
        if (exitButton != null)
        {
            exitButton.onClick.AddListener(OnExitButtonClick);
            
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
}
