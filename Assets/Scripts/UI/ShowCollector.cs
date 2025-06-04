using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowCollector : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> listTextCollector;
   


    public void UpdateCountCollector()
    {
        listTextCollector[0].text = $"{UIManager.Instance.blueDiamondCount} / {UIManager.Instance.targetBlueDiamondCount}".ToString();
        listTextCollector[1].text = $"{UIManager.Instance.redDiamondCount} / {UIManager.Instance.targetRedDiamondCount}".ToString();
        listTextCollector[2].text = $"{UIManager.Instance.greenDiamondCount} / {UIManager.Instance.targetGreenDiamondCount}".ToString();
        listTextCollector[3].text = $"{UIManager.Instance.GoldCoinCount}".ToString();
    }

    public void StartGameState()
    {
        if (GameManager.instance.gameState != GameState.None) return;

        this.gameObject.SetActive(false);
        UIManager.Instance.m_GoldCoint.SetActive(false);
        UIManager.Instance.m_MissionTilte.gameObject.SetActive(false);
    }
    public void RunGameState()
    {
        if (GameManager.instance.gameState != GameState.Run) return;

        this.gameObject.SetActive(true);
        UIManager.Instance.m_GoldCoint.SetActive(true);
        UIManager.Instance.m_MissionTilte.gameObject.SetActive(true);
    }

}
