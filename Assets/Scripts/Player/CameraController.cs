using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform m_target; //player
    private Camera m_cam;
    [SerializeField]
    private float m_smoothSpeed = 10.0f;
    private bool m_isInArena = false;

    private void Awake()
    {
        m_cam = Camera.main;
        InputManager.m_cam = m_cam;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;        
    }

    private void Update()
    {
        if (m_isInArena)
            transform.position = Vector3.Lerp(transform.position, m_target.position, m_smoothSpeed * Time.deltaTime);
    }

    private void OnSceneLoaded(Scene _scene, LoadSceneMode _mode)
    {
        m_isInArena = !(_scene.name == "Home");
        var startPos = GameObject.FindGameObjectWithTag("StartCamTransform");
        if (startPos != null)
        {
            m_cam.transform.rotation = startPos.transform.rotation;
            m_cam.transform.position = startPos.transform.position;
            var camInit = startPos.GetComponent<CameraInitializer>();
            if (camInit != null && m_isInArena)
            {
                m_cam.transform.position = m_target.position + m_cam.transform.forward * -camInit.StartDist;
            }
        }
    }
}
