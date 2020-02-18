using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public ZombieStat m_initData;
    public NavMeshAgent m_navMeshAgent;
    public CapsuleCollider m_capsuleCollider;
    public Animator m_animator;
    public MovementAnimator m_movementAnimator;
    public ParticleSystem m_particles;

    PlayerController m_player;
    bool m_isDead;
    public bool IsDead { get { return m_isDead; } }

    // Start is called before the first frame update
    void Start()
    {
        m_player = FindObjectOfType<PlayerController>();
        m_navMeshAgent.updateRotation = false;

       /* if (m_navMeshAgent)
        {
            m_navMeshAgent.SetDestination(m_player.transform.position);
            transform.rotation = Quaternion.LookRotation(m_navMeshAgent.velocity.normalized);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isDead)
            return;

        if (m_navMeshAgent)
        {
            m_navMeshAgent.SetDestination(m_player.transform.position);
            transform.rotation = Quaternion.LookRotation(m_navMeshAgent.velocity.normalized);
        }
    }

    public void Kill()
    {
        if (!m_isDead)
        {
            m_isDead = true;
            Destroy(m_capsuleCollider);
            Destroy(m_movementAnimator);
            Destroy(m_navMeshAgent);
            m_particles.Play();
            //GetComponentInChildren<ParticleSystem>().Play();
            m_animator.SetTrigger("dead");
            Destroy(gameObject, m_initData.DyingTime);//Remove object after N seconds.
        }
    }
}
