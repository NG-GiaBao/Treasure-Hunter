using EasyTransition;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public enum GameState
{
    None,
    Run,
    Pause,
    Resume,
    StartGame,
    EndGame,
    MenuGame,
}

public enum GameMap
{
    Lv1,
    Lv2
}
public class GameManager : BaseManager<GameManager>
{
    [Header("Player Heal")]
    [SerializeField] private PlayerStatSO playerStatSO;
    [SerializeField] private int playerHeal;
    [SerializeField] private InputAction pressesButton;
    public bool m_IsPlayerDeath;
    public GameState gameState;
    public GameMap gameMap;
    public bool m_IsBossActive = true;

    private void Start()
    {
      
        SetStateGame(GameState.MenuGame);
        StartGame();
    }
   
    private void StartGame()
    {
        if (UIManager.HasInstance)
        {
            UIManager.Instance.ShowScreen<ScreenMenuOpening>();
            UIManager.Instance.ShowNotify<NotifyFakeLoading>();
        }
        pressesButton.Enable();
        pressesButton.performed += OnPressesButton;


    }
    private void OnDestroy()
    {
        pressesButton.performed -= OnPressesButton;
        pressesButton.Disable();
    }
    private void OnPressesButton(InputAction.CallbackContext context)
    {
       if(UIManager.HasInstance)
        {
            UIManager.Instance.ShowPopup<PopupPauseGame>();
        }
    }
    public void LoadScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

    public void RestartGame(TransitionSettings transition, float timedelay)
    {
        string currentScene = SceneManager.GetActiveScene().name;
        TransitionManager.Instance().Transition(currentScene, transition, timedelay);
        playerHeal = playerStatSO.PlayerHealth;

    }

    public int UpdatePlayerHeal()
    {
        return playerHeal;
    }

    public void ReceriverDamge(int damage)
    {
        playerHeal -= damage;
    }

    public void SetStateGame(GameState gameState)
    {
        this.gameState = gameState;
    }
    public void SetMap(GameMap gameMap)
    {
        this.gameMap = gameMap;
    }

    IEnumerator DelayPlayer()
    {
        yield return new WaitForSeconds(2f);
        m_IsBossActive = true;
    }
}


