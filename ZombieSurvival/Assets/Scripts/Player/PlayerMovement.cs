using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public PlayerController m_player;
    public Joystick m_joystick;
    public NavMeshAgent m_navAgent;
    public bool m_isNavMeshRotation = false;

    //public Camera cam; //for test
    float m_speed;
    void Start()
    {
        // cam = FindObjectOfType<Camera>();
        m_speed = m_player.m_initialStat.Speed;
        m_navAgent.updateRotation = m_isNavMeshRotation;
        if (m_joystick == null)
        {
            m_joystick = FindObjectOfType<Joystick>();
        }
        //because player createdin run time...
        SetupFollowedCameras();
    }
    private void SetupFollowedCameras()
    {
        /*var camera = FindObjectOfType<FollowCamera>();
        if (camera)
        {
            camera.m_followedTransform = transform;
        }

        var minimap = FindObjectOfType<MiniMapCamera>();
        if (minimap)
        {
            minimap.m_followedTransform = transform;
        }*/
        foreach (var cam in FindObjectsOfType<MiniMapCamera>())
        {
            cam.m_target = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Just for test
       /* if( Input.GetMouseButtonDown(0) )
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                m_navAgent.SetDestination(hit.point);
                //MovePlayer(hit.point);
            }
            
        }*/

        Vector3 destination = Vector3.zero;
        destination.x = m_joystick.Horizontal;
        destination.z = m_joystick.Vertical;
       // if (destination != Vector3.zero)
        {
            MovePlayer(destination);
        }
    }

    private void MovePlayer( Vector3 a_destination)
    {
        //Delta time not needed for nav mesh
        m_navAgent.velocity = a_destination.normalized /** Time.deltaTime*/ * m_speed;
    }
}
