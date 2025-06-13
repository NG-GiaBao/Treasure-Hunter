using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlip : MonoBehaviour
{

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
            }
            else
            {
                this.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
       
    }
}
