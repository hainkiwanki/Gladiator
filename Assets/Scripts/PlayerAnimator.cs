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

    public void SetBool(string _name, bool _b)
    {
        // Debug.Log("Animator>> " + _name + ", turned " + _b);
        m_animator.SetBool(_name, _b);
    }

    public void SetTrigger(string _name)
    {
        m_animator.SetTrigger(_name);
    }

    public bool GetBool(string _name)
    {
        return m_animator.GetBool(_name);
    }
}
