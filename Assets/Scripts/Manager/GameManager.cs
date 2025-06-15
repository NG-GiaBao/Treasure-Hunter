using EasyTransition;
using Sirenix.OdinInspector;
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
    public bool m_IsPlayerDeath;
    public GameState gameState;
    public GameMap gameMap;
    public bool m_IsBossActive = true;

    [Header("Value Item")]
    [ShowInInspector]
    private readonly Dictionary<ItemType, int> ItemValue = new();


    private void Start()
    {
        InitDict();
        SetStateGame(GameState.MenuGame);
        StartGame();
    }
    private void InitDict()
    {
        ItemValue.Add(ItemType.Coin, 0);
        ItemValue.Add(ItemType.GreenDiamond, 0);
        ItemValue.Add(ItemType.RedDiamond, 0);
        ItemValue.Add(ItemType.BlueDiamond, 0);
    }
    public void AddItemValue(ItemType itemType,int amout = 1)
    {
        if (ItemValue.ContainsKey(itemType))
        {
            ItemValue[itemType] += amout;
            if(ListenerManager.HasInstance)
            {
                ListenerManager.Instance.BroadCast(ListenType.OnSendItemValue, (itemType, ItemValue[itemType]));
            }
        }
        else
        {
            Debug.LogError($"ItemType {itemType} not found in ItemValue dictionary.");
        }
    }
    public int GetItemValue(ItemType itemType)
    {
        if (ItemValue.ContainsKey(itemType))
        {
            return ItemValue[itemType];
        }
        else
        {
            Debug.LogError($"ItemType {itemType} not found in ItemValue dictionary.");
            return 0;
        }
    }
    private void StartGame()
    {
        if (UIManager.HasInstance)
        {
            UIManager.Instance.ShowScreen<ScreenMenuOpening>();
            UIManager.Instance.ShowNotify<NotifyFakeLoading>();
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


