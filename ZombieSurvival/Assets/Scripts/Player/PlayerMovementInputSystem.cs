using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerMovementInputSystem : MonoBehaviour
{
    public PlayerController m_player;
    public NavMeshAgent m_navAgent;
    public bool m_isNavMeshRotation = false;

    Vector3 m_moveDist = Vector3.zero;
    public PlayerInputActions m_actions;

    float m_speed;

    private void Awake()
    {
        m_actions = new PlayerInputActions();
        m_actions.Player.Move.performed += InputActionContext_Move;//ctx => m_moveDist = new Vector3( ctx.ReadValue<Vector2>();
    }
    void Start()
    {
        m_speed = m_player.m_initialStat.Speed;
        m_navAgent.updateRotation = m_isNavMeshRotation;
    }

    private void OnEnable()
    {
        m_actions.Enable();
    }

    private void OnDisable()
    {
        m_actions.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_moveDist != Vector3.zero)
        {
            MovePlayer(m_moveDist);
        }
    }

    public void InputActionContext_Move(InputAction.CallbackContext a_context)
    {
        Vector2 inputValue = a_context.ReadValue<Vector2>();
        m_moveDist.x = inputValue.x;
        m_moveDist.z = inputValue.y;
        Debug.Log($"m_moveDist = {m_moveDist}");
    }

    private void MovePlayer(Vector3 a_destination)
    {
        //Delta time not needed for nav mesh
        m_navAgent.velocity = a_destination.normalized /** Time.deltaTime*/ * m_speed;
    }
}
