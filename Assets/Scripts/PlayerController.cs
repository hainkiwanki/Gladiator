using System.Collections;
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

    [Header("Particles")]
    [SerializeField]
    private Transform m_leftFoot;
    [SerializeField]
    private Transform m_leftFootTip;
    [SerializeField]
    private Transform m_rightFoot;
    [SerializeField]
    private Transform m_rightFootTip;
    [SerializeField]
    private GameObject m_footprintParticle;
    [SerializeField]
    private GameObject m_footprintTipParticle;


    [Header("Clone Settings")]
    public GameObject m_clonePrefab;
    public int m_cloneFrameDelay = 15;
    public float m_cloneDissolveMulti = 5.0f;

    public float m_attackSpeed = 2.0f;

    private void Awake()
    {
        m_fsm = new StateMachine();
        m_fsm.SetStates(new Dictionary<System.Type, State>()
        {
            { typeof(IdleState), new IdleState(this) },
            { typeof(WalkState), new WalkState(this) },
            { typeof(RunState), new RunState(this) },
            { typeof(DodgeState), new DodgeState(this) },
            { typeof(AttackState), new AttackState(this) },
        });
        m_controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        m_fsm.OnStart();
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
        // MAKE SURE GROuND LAYER IS ON THE GROUND PLANE
        m_lookDir = (InputManager.mouseWP - transform.position).normalized;
        var distance = Vector3.Distance(transform.position, InputManager.mouseWP);
        // Debug.Log(distance);
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

    public Vector3 GetMoveDir()
    {
        return m_moveDir;
    }

    public Vector3 GetLookDir()
    {
        return m_lookDir;
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

    public void PlayBackwardFootParticle(AnimationEvent _evt)
    {
        // Debug.Log(evt.animatorClipInfo.clip.name + ", " + evt.animatorClipInfo.weight + ", " + evt.intParameter);
        var foot = _evt.intParameter;
        if (_evt.animatorClipInfo.weight > 0.5f)
        {
            var footT = (foot > 0) ? m_rightFootTip : m_leftFootTip;
            Instantiate(m_footprintTipParticle, footT);
        }
    }

    public void PlayFootprintParticle(AnimationEvent _evt) // 1 = right foot, -1 = left foot
    {
        var foot = _evt.intParameter;
        if (_evt.animatorClipInfo.weight > 0.5f)
        {
            var footT = (foot > 0) ? m_rightFoot : m_leftFoot;
            Instantiate(m_footprintParticle, footT);
        }
    }

    public void StartACoroutine(IEnumerator _co)
    {
        StartCoroutine(_co);
    }

    public void SetComboCounter(int _i)
    {
        EventManager.onAttackComboReady?.Invoke(_i);
    }

    public void EnteredIdleAnimation()
    {
        EventManager.onIdleAnimationEntered?.Invoke();
    }
}