using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInitializer : MonoBehaviour
{
    public float StartDist => m_cameraStartDistance;
    [SerializeField]
    private float m_cameraStartDistance = 11.0f;
}
