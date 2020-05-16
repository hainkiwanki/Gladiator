using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationSetter : MonoBehaviour
{
    private Animator m_anim;
    public string m_name;
    public float m_time;

    private void Awake()
    {
        m_anim = GetComponent<Animator>();
        m_anim.speed = 0.0f;
        m_anim.Play(m_name, 0, m_time);
    }

    private void Update()
    {
        m_anim.Play(m_name, 0, m_time);
    }
}
