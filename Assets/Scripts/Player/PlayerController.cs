using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float m_rotSpeed = 10.0f;
    [SerializeField]
    [Range(1, 25)]
    private float m_speed = 5.0f;
    private CharacterController m_controller;
    private Vector3 m_lookDir;
    private Camera m_cam;
    private Vector3 m_moveDir;

    [Header("Clone Settings")]
    public GameObject m_clonePrefab;
    public int m_cloneFrameDelay = 15;
    public float m_cloneDissolveMulti = 5.0f;

    public float m_attackSpeed = 2.0f;
    public int m_comboCount = 3;

    private void Awake()
    {
        m_controller = GetComponent<CharacterController>();
        m_cam = Camera.main;
    }

    public void Move(Vector2 _input)
    {
        m_moveDir = _input.x * m_cam.transform.right + _input.y * m_cam.transform.forward;
        m_moveDir.y = 0.0f;
        m_controller.Move(m_moveDir.normalized * m_speed * Time.deltaTime);
        RotateTowards(m_moveDir);
    }

    private void RotateTowards(Vector3 _direction)
    {
        if (_direction == Vector3.zero) return;
        var rot = Quaternion.LookRotation(_direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, m_rotSpeed * Time.deltaTime);
    }

    public void Teleport(Vector3 _pos)
    {
        m_controller.enabled = false;
        transform.position = _pos;
        m_controller.enabled = true;
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

    public Vector3 TransformVector3ToLocal(Vector3 _absDir)
    {
        var angle = Vector3.SignedAngle(Vector3.forward, transform.forward, Vector3.up);
        return Quaternion.Euler(0.0f, -angle, 0.0f) * _absDir;
    }

    public void StartACoroutine(IEnumerator _co)
    {
        StartCoroutine(_co);
    }
}