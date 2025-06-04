using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private string menuNameScene;
    [SerializeField] private TransitionSettings LoadMenuTransitionSettings;
    [SerializeField] private float timeDelay;
    public void PauseGame()
    {
        if(GameManager.instance.gameState == GameState.Run)
        {
            GameManager.instance.PauseGame();
            gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
        
    }
    public void BackToMenuOnClick()
    {
        GameManager.instance.gameState = GameState.None;
        Time.timeScale = 1.0f;
        UIManager.Instance.LoadSceneTransition(menuNameScene, LoadMenuTransitionSettings, timeDelay);
        this.gameObject.SetActive(false);
        UIManager.Instance.BackToMenuOpening();
        AudioManager.instance.MenuGameMusic();
        UIManager.Instance.m_GoldCoint.gameObject.SetActive(false);
        UIManager.Instance.m_MissionTilte.gameObject.SetActive(false);

    }
    public void ResumeOnClick()
    {
        GameManager.instance.gameState = GameState.Run;
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
