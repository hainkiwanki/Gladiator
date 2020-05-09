using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private PlayerController m_controller;
    private Animator m_animator;

    private void Awake()
    {
        m_controller = GetComponent<PlayerController>();
        m_animator = GetComponent<Animator>();
    }

    private void Update()
    {
        m_animator.SetFloat("xdir", m_controller.MoveX);
        m_animator.SetFloat("zdir", m_controller.MoveZ);
    }

}
