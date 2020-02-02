using UnityEngine;
using UnityEngine.AI;

public class MovementAnimator : MonoBehaviour
{
    public NavMeshAgent m_navMeshAgent;
    public Animator m_animator;

    // Start is called before the first frame update
    void Start()
    {
        /*navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();*/
    }

    // Update is called once per frame
    void Update()
    {
        m_animator.SetFloat("speed", m_navMeshAgent.velocity.magnitude);

        //Debug.Log($"navMeshAgent.velocity.magnitude = {m_navMeshAgent.velocity.magnitude}");
    }
}
