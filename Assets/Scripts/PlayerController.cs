using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float m_rotSpeed = 10.0f;
    private StateMachine m_fsm;
    private float m_speed, m_goalSpeed;
    private float m_speedChange = 5.0f;
    private Vector3 m_animDir, m_goalAnimDir;
    private Vector3 m_moveDir, m_goalMoveDir;
    private CharacterController m_controller;
    private Vector3 m_lookDir;
    public bool IsRunning => m_isRunning;
    private bool m_isRunning = false;
    public bool HasAttacked => m_hasAttacked;
    private bool m_hasAttacked = false;

    public bool HasKicked => m_hasKicked;
    private bool m_hasKicked = false;

    public bool IsBlocking => m_isBlocking;
    private bool m_isBlocking = false;

    private void Awake()
    {
        m_fsm = new StateMachine();
        m_fsm.SetStates(new Dictionary<System.Type, State>()
        {
            { typeof(IdleState), new IdleState(this) },
            { typeof(WalkState), new WalkState(this) },
            { typeof(RunState), new RunState(this) },
            { typeof(AttackState), new AttackState(this) },
            { typeof(DodgeState), new DodgeState(this) },
            { typeof(BlockState), new BlockState(this) },
            { typeof(KickState), new KickState(this) },
        });
        m_controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        InputManager.playerInput.Run.performed += _ => m_isRunning = true;
        InputManager.playerInput.Run.canceled += _ => m_isRunning = false;
        InputManager.playerInput.Attack.performed += _ => m_hasAttacked = true;
        InputManager.playerInput.Attack.canceled += _ => m_hasAttacked = false;
        InputManager.playerInput.Kick.performed += _ => m_hasKicked = true;
        InputManager.playerInput.Kick.canceled += _ => m_hasKicked = false;
        InputManager.playerInput.Block.performed += _ => m_isBlocking = true;
        InputManager.playerInput.Block.canceled += _ => m_isBlocking = false;
    }

    private void Update()
    {
        m_speed = Mathf.Lerp(m_speed, m_goalSpeed, Time.deltaTime * m_speedChange);
        m_animDir = Vector3.Lerp(m_animDir, m_goalAnimDir, Time.deltaTime * m_speedChange);
        m_moveDir = Vector3.Lerp(m_moveDir, m_goalMoveDir, Time.deltaTime * m_speedChange);
        m_fsm.Update();
    }

    public void Move()
    {
        m_controller.Move(m_moveDir * m_speed * Time.deltaTime);
    }

    public void RotateToMousePos()
    {
        m_lookDir = (InputManager.mouseWP - transform.position).normalized;
        var distance = Vector3.Distance(transform.position, InputManager.mouseWP);
        if (distance < 0.5f)
        {
            return;
        }
        if (m_lookDir != Vector3.zero)
        {
            m_lookDir.y = 0.0f;
            var targetRot = Quaternion.LookRotation(m_lookDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, m_rotSpeed * Time.deltaTime);
        }
    }

    public void SetGoalSpeed(float _speed, bool _instant = false)
    {
        m_goalSpeed = _speed;
        if (_instant)
            m_speed = m_goalSpeed;
    }

    public void SetMoveDir(Vector3 _dir)
    {
        m_goalMoveDir = m_moveDir = _dir;
    }

    public void SetGoalAnimationDirection(Vector3 _dir, float _multi = 1.0f, bool _instant = false)
    {
        m_goalMoveDir = _dir;
        m_goalAnimDir.z = Vector3.Dot(_dir, m_lookDir);
        var perpen = Vector3.Cross(Vector3.up, _dir);
        var dot = Vector3.Dot(m_lookDir, perpen);
        m_goalAnimDir.x = -dot;
        m_goalAnimDir *= _multi;

        if (_instant)
        {
            m_animDir = m_goalAnimDir;
            m_moveDir = m_goalMoveDir;
        }
    }

    public Vector3 GetAnimationDirection()
    {
        return m_animDir;
    }

    public Vector3 TransformVector3ToLocal(Vector3 _absDir)
    {
        var angle = Vector3.SignedAngle(Vector3.forward, transform.forward, Vector3.up);
        return Quaternion.Euler(0.0f, -angle, 0.0f) * _absDir;
    }
}