using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Zombie", menuName = "ZombieSurvival/Zombie")]
public class ZombieStat : ScriptableObject
{
    public int HP = 100;
    public float Damage = 10;
    public float AttackRate = 1;
    public Vector2 Speed;
    public float DyingTime = 5f;
}
