using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleController : MonoBehaviour
{
    private ParticleSystem m_ps;
    private bool m_hasStarted = false;

    private void Awake()
    {
        m_ps = GetComponent<ParticleSystem>();
        m_ps.Play();
        m_hasStarted = true;
    }

    private void Update()
    {
        if (m_hasStarted)
        {
            if (m_ps.isStopped)
                Destroy(gameObject);
        }
    }
}
