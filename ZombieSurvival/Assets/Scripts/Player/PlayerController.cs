using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    //public NavMeshAgent m_navAgent;
    public PlayerStats m_initialStat;

    float m_currentHealth;
    float m_nextAttackTime;

    // Start is called before the first frame update
    void Start()
    {
        m_currentHealth = m_initialStat.HP;
        m_nextAttackTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }


}
