using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardVictory : MonoBehaviour
{
    [SerializeField] private string menuNameScene;
    [SerializeField] private string nameNextLevelScene;
    [SerializeField] private TransitionSettings LoadMenuTransitionSettings;
    [SerializeField] private TransitionSettings NextToLevelTransitionSettings;
    [SerializeField] private float timeDelay;
    public void BackToMenuOnClick()
    {
        GameManager.instance.gameState = GameState.None;
        UIManager.Instance.LoadSceneTransition(menuNameScene, LoadMenuTransitionSettings, timeDelay);
        this.gameObject.SetActive(false);
        UIManager.Instance.BackToMenuOpening();
        AudioManager.instance.MenuGameMusic();
        UIManager.Instance.m_MissionTilte.gameObject.SetActive(false);
        UIManager.Instance.m_GoldCoint.SetActive(false);
    }
    public void NextToLevelOnClick()
    {
        UIManager.Instance.LoadSceneTransition(nameNextLevelScene, NextToLevelTransitionSettings, timeDelay);
        this.gameObject.SetActive(false);
        GameManager.instance.NextMapLv2();
        UIManager.Instance.m_IsWin = false;
        UIManager.Instance.RestartGameState();
        AudioManager.instance.NextGameMusic();

    }
}
