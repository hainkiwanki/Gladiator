﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator m_animator;

    private Dictionary<string, bool> m_animationVariables;

    private void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_animationVariables = new Dictionary<string, bool>()
        {
            { "kickdone", false }
        };
    }

    public void SetDirection(string _name, Vector3 _dir)
    {
        m_animator.SetFloat("x"+_name, _dir.x);
        m_animator.SetFloat("z"+_name, _dir.z);
    }

    public void SetBool(string _name, bool _b)
    {
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

    public AnimatorStateInfo GetAnimationClipInfo()
    {
        return m_animator.GetCurrentAnimatorStateInfo(0);
    }

    public bool IsAnimationPlaying(string _name)
    {
        return (m_animator.GetCurrentAnimatorStateInfo(0).IsName(_name));
    }

    public void EventAnimationVariable(string _name)
    {
        SetAnimationVariable(_name, true);
    }

    public void SetAnimationVariable(string _name, bool _value)
    {
        if (!m_animationVariables.ContainsKey(_name))
        {
            Debug.LogError("Key \"" + _name + "\" does not exist");
            return;
        }
        m_animationVariables[_name] = _value;
    }
    
    public bool GetAnimationVariable(string _name)
    {
        if (!m_animationVariables.ContainsKey(_name))
        {
            Debug.LogError("Key \"" + _name + "\" does not exist");
            return false;
        }
        return m_animationVariables[_name];
    }
}
