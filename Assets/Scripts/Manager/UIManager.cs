using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Link Ui")]
    public BoardGameOver boardGameOver;
    public BoardVictory boardVictory;
    public ShowCollector showCollector;
    public ShowPlayerHeal showPlayerHeal;
    public OpeningPanel openingPanel;
    public PausePanel pausePanel;
    public GameObject m_GoldCoint;
    public TextMeshProUGUI m_MissionTilte;
    [SerializeField] private List<GameObject> listPanel = new();


    [Header("GoldCoin")]
    public int GoldCoinCount;

    [Header("Blue Diamond")]
    public int blueDiamondCount;
    public int targetBlueDiamondCount;
    [Header("Red Diamond")]
    public int redDiamondCount;
    public int targetRedDiamondCount;
    [Header("Green Diamond")]
    public int greenDiamondCount;
    public int targetGreenDiamondCount;

    [Header("List Text Collector")]
    [SerializeField] private List<TextMeshProUGUI> listTextCollector;

    //[SerializeField] private TransitionSettings ResetGametransition;
    //[SerializeField] private TransitionSettings Menutransition;
    //[SerializeField] private float loadDelay;
    //[SerializeField] private string m_MenuScene;

    [Header("Slider & Toggle Sound")]
    [SerializeField] private Slider m_SoundSlider;
    [SerializeField] private Toggle m_SoundToggle;
    [SerializeField] private AudioSource EffectAudioSource;

    [Header("Slider & Toggle Music")]
    [SerializeField] private Slider m_MusicSlider;
    [SerializeField] private Toggle m_MusicToggle;
    [SerializeField] private AudioSource backGroundaudioSource;

    public bool m_IsWin;

    public static UIManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Init();
        DiamondCollider.OnDiamondCollected += HandleDiamondCollected;
        SetTargetCountDiamondsLv1();
        showCollector.UpdateCountCollector();
        showCollector.StartGameState();

        showPlayerHeal.StartGameState();

        float saveSoundVolumn = PlayerPrefs.GetFloat("SoundVolumn");
        float saveMusicVolumn = PlayerPrefs.GetFloat("MusicVolumn");

        m_SoundSlider.value = saveSoundVolumn;
        EffectAudioSource.volume = saveSoundVolumn;
        m_SoundToggle.isOn = saveSoundVolumn <= 0;

        m_MusicSlider.value = saveMusicVolumn;
        backGroundaudioSource.volume = saveMusicVolumn;
        m_MusicToggle.isOn = saveMusicVolumn <= 0;
    }
    private void Update()
    {
        UpdateSoundVolum();
        UpDateToggleSound();
        UpdateMusicVolum();
        UpDateToggleMusic();
        EscapeOnClick();
        showCollector.UpdateCountCollector();
        if (GameManager.instance.gameState == GameState.Run)
        {
            StartCoroutine(DelayShowPanel());
        }
        CheckCompleleMapLv1();

        if(GameManager.instance.gameMap == GameMap.Lv2)
        {
            StartCoroutine(DelaySetTarget());
        }

    }
    private void OnDestroy()
    {
        DiamondCollider.OnDiamondCollected -= HandleDiamondCollected;
    }
    public void OnBoardGameOver()
    {
        boardGameOver.gameObject.SetActive(true);
    }
    private void Init()
    {
        listPanel.Add(boardGameOver.gameObject);
        listPanel.Add(boardVictory.gameObject);

        foreach (GameObject go in listPanel)
        {
            go.SetActive(false);
        }
    }
    private void HandleDiamondCollected(string CollectorName, int amout)
    {
        {
            switch (CollectorName)
            {
                case "BlueDiamond":
                    blueDiamondCount += amout;
                    break;
                case "RedDiamond":
                    redDiamondCount += amout;
                    break;
                case "GreenDiamond":
                    greenDiamondCount += amout;
                    break;
                case "GoldCoin":
                    GoldCoinCount += amout;
                    break;
            }
        }
    }
    private bool CheckIsMapLv1MisionComplele()
    {
        bool isWin = false;
        if (blueDiamondCount == targetBlueDiamondCount
           && redDiamondCount == targetRedDiamondCount
           && greenDiamondCount == targetGreenDiamondCount)
        {
            isWin = true;
        }
        return isWin;
    }
    private void SetTargetCountDiamondsLv1()
    {
        targetBlueDiamondCount = 1;
        targetGreenDiamondCount = 1;
        targetRedDiamondCount = 1;
    }

    private void SetTargetCountDiamondsL2()
    {
        targetBlueDiamondCount = 2;
        targetGreenDiamondCount = 1;
        targetRedDiamondCount = 2;
    }

    
    private void ResetCountDimaond()
    {
        blueDiamondCount = 0;
        greenDiamondCount = 0;
        redDiamondCount = 0;
    }
    public bool CheckIsWin()
    {
        if (CheckIsMapLv1MisionComplele())
        {
            m_IsWin = true;
        }
        return m_IsWin;
    }
    private void CheckCompleleMapLv1()
    {
        if (CheckIsMapLv1MisionComplele())
        {
            if (GameManager.instance.gameMap == GameMap.Lv1)
            {
                boardVictory.gameObject.SetActive(true);
            }
            else
            {
                boardVictory.gameObject.SetActive(false);
            }
        }
    }
    private void CheckCompleleMapLv2()
    {
        if (CheckIsMapLv1MisionComplele())
        {
            if (GameManager.instance.gameMap == GameMap.Lv2)
            {
                boardVictory.gameObject.SetActive(true);
            }
            else
            {
                boardVictory.gameObject.SetActive(false);
            }
        }
    }

    public void LoadSceneTransition(string nameScene, TransitionSettings transitionSettings, float timeDelay)
    {
        TransitionManager.Instance().Transition(nameScene, transitionSettings, timeDelay);
    }
    #region Hàm cập nhật âm thanh và soundFX
    public void UpdateSoundVolum()
    {
        EffectAudioSource.volume = m_SoundSlider.value;
        PlayerPrefs.SetFloat("SoundVolumn", EffectAudioSource.volume);
    }
    public void UpdateMusicVolum()
    {
        backGroundaudioSource.volume = m_MusicSlider.value;
        PlayerPrefs.SetFloat("MusicVolumn", backGroundaudioSource.volume);
    }
    public void UpDateToggleMusic()
    {
        if (backGroundaudioSource.volume <= 0)
        {
            m_MusicToggle.isOn = true;
        }
        else
        {
            m_MusicToggle.isOn = false;
        }
    }
    public void UpDateToggleSound()
    {
        if (EffectAudioSource.volume <= 0)
        {
            m_SoundToggle.isOn = true;
        }
        else
        {
            m_SoundToggle.isOn = false;
        }
    }
    #endregion
    public void BackToMenuOpening()
    {
        showPlayerHeal.gameObject.SetActive(false);
        showCollector.gameObject.SetActive(false);
        StartCoroutine(DelayShowOpening());
    }

    public void EscapeOnClick()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausePanel.PauseGame();
        }
    }

    public void RestartGameState()
    {
        ResetCountDimaond();
    }
    private IEnumerator DelayShowPanel()
    {
        yield return new WaitForSeconds(1f);
        showCollector.RunGameState();
        showPlayerHeal.RunGameState();
        openingPanel.RunGameState();
    }

    private IEnumerator DelayShowOpening()
    {
        yield return new WaitForSeconds(1f);
        openingPanel.gameObject.SetActive(true);
    }
    private IEnumerator DelaySetTarget()
    {
        yield return new WaitForSeconds(1f);
        SetTargetCountDiamondsL2();
    }
}
