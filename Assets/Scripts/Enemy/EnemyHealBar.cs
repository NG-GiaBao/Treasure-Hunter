using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealBar : MonoBehaviour
{
    [SerializeField] private Slider m_EnemyHealthBar;
    [SerializeField] private EnemyHeal m_EnemyHeath;
    [SerializeField] private EnemyStatSO m_EnemyStatSO;
    private void Awake()
    {
        m_EnemyHeath = GetComponent<EnemyHeal>();
       
    }
    // Start is called before the first frame update
    void Start()
    {
        m_EnemyHealthBar.maxValue = m_EnemyStatSO.EnemyHealth;
        m_EnemyHealthBar.value = m_EnemyStatSO.EnemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealBar();
    }

    private void UpdateHealBar()
    {
        m_EnemyHealthBar.value = m_EnemyHeath.GetEnemyHeal();
    }
}
