//using EasyTransition;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class BoardVictory : MonoBehaviour
//{
//    [SerializeField] private string menuNameScene;
//    [SerializeField] private string nameNextLevelScene;
//    [SerializeField] private TransitionSettings LoadMenuTransitionSettings;
//    [SerializeField] private TransitionSettings NextToLevelTransitionSettings;
//    [SerializeField] private float timeDelay;
//    public void BackToMenuOnClick()
//    {
//        GameManager.Instance.gameState = GameState.None;
//        HandlerManager.Instance.LoadSceneTransition(menuNameScene, LoadMenuTransitionSettings, timeDelay);
//        this.gameObject.SetActive(false);
//        HandlerManager.Instance.BackToMenuOpening();
//        AudioManager.Instance.MenuGameMusic();
//        HandlerManager.Instance.m_MissionTilte.gameObject.SetActive(false);
//        HandlerManager.Instance.m_GoldCoint.SetActive(false);
//    }
//    public void NextToLevelOnClick()
//    {
//        HandlerManager.Instance.LoadSceneTransition(nameNextLevelScene, NextToLevelTransitionSettings, timeDelay);
//        this.gameObject.SetActive(false);
//        GameManager.Instance.SetMap(GameMap.Lv2);
//        HandlerManager.Instance.m_IsWin = false;
//        HandlerManager.Instance.RestartGameState();
//        AudioManager.Instance.NextGameMusic();

//    }
//}
