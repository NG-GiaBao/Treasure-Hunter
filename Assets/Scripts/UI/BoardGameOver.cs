using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGameOver : MonoBehaviour
{
    [SerializeField] private TransitionSettings LoadMenuTransitionSettings;
    [SerializeField] private TransitionSettings CurrentSceneTransitionSettings;
    [SerializeField] private string menuNameScene;
    [SerializeField] private float timeDelay;
   
    public void RestartOnClick()
    {
        GameManager.Instance.RestartGame(CurrentSceneTransitionSettings, timeDelay);
        Time.timeScale = 1f;
        GameManager.Instance.m_IsPlayerDeath = false;
        this.gameObject.SetActive(false);
        HandlerManager.Instance.RestartGameState();
        if (GameManager.Instance.gameMap == GameMap.Lv1) AudioManager.Instance.PlayGameMusic();
        else if(GameManager.Instance.gameMap == GameMap.Lv2) AudioManager.Instance.NextGameMusic();
        GameManager.Instance.m_IsBossActive = false;
    }

    public void BackToMenuOnClick()
    {
        
        GameManager.Instance.gameState = GameState.None;
        HandlerManager.Instance.LoadSceneTransition(menuNameScene, LoadMenuTransitionSettings, timeDelay);
        this.gameObject.SetActive(false);
        HandlerManager.Instance.BackToMenuOpening();
        AudioManager.Instance.MenuGameMusic();
        HandlerManager.Instance.m_MissionTilte.gameObject.SetActive(false );
        HandlerManager.Instance.m_GoldCoint.SetActive(false );
    }
    private IEnumerator DelayBossActivation()
    {
        yield return new WaitForSeconds(1f); // Thời gian chờ
        GameManager.Instance.m_IsBossActive = false; // Kích hoạt boss
    }
}
