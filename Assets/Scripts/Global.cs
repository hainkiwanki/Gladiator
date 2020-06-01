using UnityEngine;
using UnityEngine.SceneManagement;

public class Global : Singleton<Global>
{
    private Scene m_currentScene;
    [SerializeField]
    private GameObject m_playerPrefab;
    private bool m_isLoadingScene = false;

    protected override void _OnAwake()
    {
        InputManager.Awake();
        m_currentScene = SceneManager.GetActiveScene();
    }

    protected override void _OnStart()
    {
        if(PlayerData.playerObject == null)
            PlayerData.playerObject = Instantiate(m_playerPrefab, Vector3.zero, Quaternion.identity);

        SceneManager.sceneLoaded += OnSceneSwitched;
    }

    private void OnEnable()
    {
        InputManager.OnEnable();
    }

    private void OnDisable()
    {
        InputManager.OnDisable();        
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneSwitched;
    }

    private void Update()
    {
        InputManager.Update();
    }

    private void LateUpdate()
    {
        InputManager.LateUpdate();
    }

    public void SceneSwitch()
    {
        if (m_currentScene != null && m_isLoadingScene) return;

        PlayerData.playerController.Teleport(Vector3.zero);
        m_isLoadingScene = true;
        if (m_currentScene.name == "Home")
        {
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
        }
        else if (m_currentScene.name == "Main")
        {
            SceneManager.LoadScene("Home", LoadSceneMode.Single);
        }
    }

    private void OnSceneSwitched(Scene _scene, LoadSceneMode _mode)
    {
        m_isLoadingScene = false;
        m_currentScene = _scene;
    }

}
