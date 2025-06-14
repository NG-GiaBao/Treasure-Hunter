using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    None,
    Run,
    Pause,
    Resume,
    StartGame,
    EndGame,
}

public enum GameMap
{
    Lv1,
    Lv2
}
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
       SetStateGame(GameState.StartGame);
        StartGame();
        //playerHeal = playerStatSO.PlayerHealth;
        ////BulletController.OnGetBulletDmg += ReceriverDamge;
    }
    //private void Update()
    //{
    //    if(m_IsPlayerDeath && gameMap == GameMap.Lv2)
    //    {
    //        m_IsBossActive = false;
    //    }
    //    else if(!m_IsPlayerDeath && gameMap == GameMap.Lv2)
    //    {
    //        StartCoroutine(DelayPlayer());
    //    }
    //}
    private void OnDisable()
    {
        //BulletController.OnGetBulletDmg -= ReceriverDamge;
    }
    private void StartGame()
    {
        if(UIManager.HasInstance)
        {
            UIManager.Instance.ShowScreen<ScreenMenuOpening>();
        }
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


