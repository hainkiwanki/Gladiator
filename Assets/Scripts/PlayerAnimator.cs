using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator m_animator;

    private void Awake()
    {
        m_animator = GetComponent<Animator>();
    }

    public void SetDirection(Vector3 _dir)
    {
        m_animator.SetFloat("xdir", _dir.x);
        m_animator.SetFloat("zdir", _dir.z);
    }
}
