using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlip : MonoBehaviour
{
    [Header("Stat Flip Enemy")]
    [SerializeField] private bool m_IsEnemyDirectionRight = false;

    private void Start()
    {
        EnemyDetectedPlayer.OnValueEnemyFlipPlayer += Flip;
    }
    private void OnDestroy()
    {
        EnemyDetectedPlayer.OnValueEnemyFlipPlayer -= Flip;
    }
    private void Flip(float ValueFlipDirection, GameObject gameObject)
    {
        if(gameObject == this.gameObject)
        {
            if (ValueFlipDirection < 0)
            {
                this.transform.localScale = new Vector3(1f, 1f, 1f);
                m_IsEnemyDirectionRight = true;
            }
            else
            {
                this.transform.localScale = new Vector3(-1f, 1f, 1f);
                m_IsEnemyDirectionRight = false;
            }
        }
       
    }
}
