using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowCollector : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> listTextCollector;
   


    public void UpdateCountCollector()
    {
        listTextCollector[0].text = $"{HandlerManager.Instance.blueDiamondCount} / {HandlerManager.Instance.targetBlueDiamondCount}".ToString();
        listTextCollector[1].text = $"{HandlerManager.Instance.redDiamondCount} / {HandlerManager.Instance.targetRedDiamondCount}".ToString();
        listTextCollector[2].text = $"{HandlerManager.Instance.greenDiamondCount} / {HandlerManager.Instance.targetGreenDiamondCount}".ToString();
        listTextCollector[3].text = $"{HandlerManager.Instance.GoldCoinCount}".ToString();
    }

    public void StartGameState()
    {
        if (GameManager.Instance.gameState != GameState.None) return;

        this.gameObject.SetActive(false);
        HandlerManager.Instance.m_GoldCoint.SetActive(false);
        HandlerManager.Instance.m_MissionTilte.gameObject.SetActive(false);
    }
    public void RunGameState()
    {
        if (GameManager.Instance.gameState != GameState.Run) return;

        this.gameObject.SetActive(true);
        HandlerManager.Instance.m_GoldCoint.SetActive(true);
        HandlerManager.Instance.m_MissionTilte.gameObject.SetActive(true);
    }

}
