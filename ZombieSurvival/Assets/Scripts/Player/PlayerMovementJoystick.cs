using UnityEngine;
using UnityEngine.AI;

public class PlayerMovementJoystick : MonoBehaviour
{
   /* public PlayerController m_player;
    public Joystick m_joystick;
    public NavMeshAgent m_navAgent;
    public bool m_isNavMeshRotation = false;

    float m_speed;
    void Start()
    {
        m_speed = m_player.m_initialStat.Speed;
        m_navAgent.updateRotation = m_isNavMeshRotation;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 destination = Vector3.zero;
        destination.x = m_joystick.Horizontal;
        destination.z = m_joystick.Vertical;
        if (destination != Vector3.zero)
        {
            MovePlayer(destination);
        }
    }

    private void MovePlayer( Vector3 a_destination)
    {
        //Delta time not needed for nav mesh
        m_navAgent.velocity = a_destination.normalized * m_speed;
    }*/
}
