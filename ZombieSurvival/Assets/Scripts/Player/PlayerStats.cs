using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "ZombieSurvival/Player")]
public class PlayerStats : ScriptableObject
{
    public int HP = 100;
    public float Damage = 10;
    public float AttackDelay = 0.5f;
    public float Speed;
}
