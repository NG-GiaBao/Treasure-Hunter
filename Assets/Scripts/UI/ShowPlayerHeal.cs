using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPlayerHeal : MonoBehaviour
{
    public void StartGameState()
    {
        if (GameManager.Instance.gameState != GameState.None) return;

        this.gameObject.SetActive(false);

    }

    public void RunGameState()
    {
        if (GameManager.Instance.gameState != GameState.Run) return;

        this.gameObject.SetActive(true);
    }
}
