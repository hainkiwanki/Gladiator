using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{
    public float SpeedMulti
    {
        get { return m_multiplier; }
        set { m_multiplier = value; }
    }

    [SerializeField]
    private Renderer[] m_rend;
    private float m_time = 0.0f;
    private float m_multiplier = 1.0f;

    private void Update()
    {
        m_time += Time.deltaTime * m_multiplier;
        if (m_time >= 1.0f)
            Destroy(gameObject);
        foreach (var r in m_rend)
        {
            foreach(var m in r.materials)
            {
                m.SetFloat("_GradientTime", m_time);
            }
        }
    }
}
