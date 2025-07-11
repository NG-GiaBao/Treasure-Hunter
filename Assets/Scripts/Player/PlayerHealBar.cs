using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealBar : MonoBehaviour
{
    [SerializeField] private Slider m_PlayerHealBar;


    void Start()
    {
        m_PlayerHealBar.maxValue = NewPlayerManager.Instance.m_NewPlayerHeal.ResetPlayerHeal();
        m_PlayerHealBar.value = NewPlayerManager.Instance.m_NewPlayerHeal.ResetPlayerHeal();
        
    }
    private void Update()
    {
        UpdataPlayerHeal();
    }
    private void UpdataPlayerHeal()
    {
        
        m_PlayerHealBar.value = NewPlayerManager.Instance.m_NewPlayerHeal.UpdatePlayerHeal();
    }

    
}
