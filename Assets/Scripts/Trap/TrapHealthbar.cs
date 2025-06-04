using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrapHealthbar : MonoBehaviour
{
    [SerializeField] private Slider m_TrapHealthBar;
    [SerializeField] private TrapHeal m_TrapHeath;
    [SerializeField] private TrapStatSO m_TrapStatSO;

    private void Awake()
    {
        m_TrapHeath = GetComponent<TrapHeal>();
    }
    // Start is called before the first frame update
    void Start()
    {
        m_TrapHealthBar.maxValue = m_TrapStatSO.TrapHealth;
        m_TrapHealthBar.value = m_TrapStatSO.TrapHealth;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
    }
    private void UpdateHealth()
    {
        if(m_TrapHealthBar != null&& m_TrapHeath != null)
        {
            m_TrapHealthBar.value = m_TrapHeath.GetEnemyHealth();
        }
    }
}
