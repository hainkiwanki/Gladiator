using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualInput : MonoBehaviour
{
    private Camera m_cam;
    private CharacterControl m_control;

    private void Awake()
    {
        m_control = GetComponent<CharacterControl>();
        m_cam = Camera.main;
    }

    private void Update()
    {
        var input = InputManager.inputDirection;
        m_control.direction = input.x * m_cam.transform.right + input.y * m_cam.transform.forward;
        m_control.direction.y = 0.0f;
    }
}
