using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[createassetmenu(filename = "enemy stat", menuname = "new enemy stat")]
[CreateAssetMenu(fileName = "Enemy stat" , menuName ="New Enemy Stat")]
public class EnemyStatSO : ScriptableObject
{
    public int EnemyHealth;
}
