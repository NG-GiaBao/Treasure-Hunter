using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPlayerHeal : MonoBehaviour
{
    public void StartGameState()
    {
        if (GameManager.instance.gameState != GameState.None) return;

        this.gameObject.SetActive(false);

    }

    public void RunGameState()
    {
        if (GameManager.instance.gameState != GameState.Run) return;

        this.gameObject.SetActive(true);
    }
}
