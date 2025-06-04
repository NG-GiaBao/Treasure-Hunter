using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPLayerDeath : MonoBehaviour
{
    [SerializeField] private Vector2 m_DeathForce;

    private void Start()
    {
        NewPlayerManager.instance.m_NewPlayerHeal.OnSendStatePlayerDeath += ForceCheckDeath;
    }
    private void OnDestroy()
    {
        NewPlayerManager.instance.m_NewPlayerHeal.OnSendStatePlayerDeath -= ForceCheckDeath;
    }

    public void ForceCheckDeath(bool isPlayerDeath)
    {
        if(isPlayerDeath)
        {
            NewPlayerManager.instance.m_NewPlayerAnimation.GetAnimator().SetTrigger("IsDeath");
        
            //StartCoroutine(DelayShowGameOver());
            if (transform.localScale.x < 0)
            {
                Debug.Log("aa");
                NewPlayerManager.instance.m_NewPlayerMove.m_PlayerRb.velocity = new(-m_DeathForce.x, m_DeathForce.y);
            }
            else
            {
                Debug.Log("cc");
                NewPlayerManager.instance.m_NewPlayerMove.m_PlayerRb.velocity = new(m_DeathForce.x, m_DeathForce.y);
            }
        }
       
        
    }

    //public IEnumerator DelayShowGameOver()
    //{
    //    yield return new WaitForSeconds(2f);
    //    //UIManager.Instance.OnBoardGameOver();
    //    Time.timeScale = 0f;
    //}
}
