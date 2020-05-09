using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform m_target; //player
    private Camera m_cam;
    [SerializeField]
    private float m_smoothSpeed = 10.0f;
    [SerializeField]
    private float m_distance = 14.0f;

    private void Awake()
    {
        m_cam = Camera.main;
        m_cam.transform.position = m_target.position + m_cam.transform.forward * -m_distance;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, m_target.position, m_smoothSpeed * Time.deltaTime);
    }
}
