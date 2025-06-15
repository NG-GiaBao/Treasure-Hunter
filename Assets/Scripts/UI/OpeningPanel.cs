//using EasyTransition;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor;
//using UnityEngine;

//public class OpeningPanel : MonoBehaviour
//{
//    [SerializeField] private Canvas intructionCanvas;
//    [SerializeField] private Canvas settingCanvas;
//    [SerializeField] private string gamePlayScene;
//    [SerializeField] private TransitionSettings gamePlaySceneTransitionSettings;
//    [SerializeField] private float timeDelay;
//    public void StartButton()
//    {
//        HandlerManager.Instance.LoadSceneTransition(gamePlayScene, gamePlaySceneTransitionSettings, timeDelay);
//        GameManager.Instance.SetStateGame(GameState.Run);
//        GameManager.Instance.SetMap(GameMap.Lv1);
//        AudioManager.Instance.PlayGameMusic();
//    }
//    public void IntructionButton()
//    {
//        intructionCanvas.gameObject.SetActive(true);
//    }

//    public void SettingButton()
//    {
//        settingCanvas.gameObject.SetActive(true);
//    }
//    public void ExitButton()
//    {
//#if UNITY_EDITOR
//        if(EditorApplication.isPlaying)
//        {
//            EditorApplication.isPlaying = false;
//        }
//#endif
//        Application.Quit();
//    }

//    public void RunGameState()
//    {
//        if (GameManager.Instance.gameState != GameState.Run) return;

//        this.gameObject.SetActive(false);
//    }
//}
