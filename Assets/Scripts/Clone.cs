using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{
    [SerializeField]
    private Renderer[] m_rend;
    private float m_time = 0.0f;

    private void Update()
    {
        m_time += Time.deltaTime;
        foreach (var r in m_rend)
        {
            foreach(var m in r.materials)
            {
             
                m.SetFloat("_GradientTime", m_time);
                Debug.Log(m_time);
            }
        }
    }
}
