using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Player Heal")]
    [SerializeField] private PlayerStatSO playerStatSO;
    [SerializeField] private int playerHeal;
    public bool m_IsPlayerDeath;
    public GameState gameState;
    public GameMap gameMap;
    public bool m_IsBossActive = true;

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        StartGame();
        playerHeal = playerStatSO.PlayerHealth;
        //BulletController.OnGetBulletDmg += ReceriverDamge;
    }
    private void Update()
    {
        if(m_IsPlayerDeath && gameMap == GameMap.Lv2)
        {
            m_IsBossActive = false;
        }
        else if(!m_IsPlayerDeath && gameMap == GameMap.Lv2)
        {
            StartCoroutine(DelayPlayer());
        }
    }
    private void OnDisable()
    {
        //BulletController.OnGetBulletDmg -= ReceriverDamge;
    }
    public void LoadScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

    public void RestartGame(TransitionSettings transition,float timedelay)
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

    public GameState StartGame()
    {
       gameState = GameState.None ;
        return gameState;
    }
    public GameState PauseGame()
    {
        gameState = GameState.Pause;
        return gameState;
    }

    public GameState RunGame()
    {
        gameState = GameState.Run;
        return gameState;
    }
    public GameMap StartMap()
    {
        gameMap = GameMap.Lv1 ;
        return gameMap;
    }
    public GameMap NextMapLv2()
    {
        gameMap = GameMap.Lv2;
        return gameMap;
    }

    IEnumerator DelayPlayer()
    {
        yield return new WaitForSeconds(2f);
        m_IsBossActive = true;
    }
}

public enum GameState
{
    None,
    Run,
    Pause,
    Resume
}

public enum GameMap
{
    Lv1,
    Lv2
}
