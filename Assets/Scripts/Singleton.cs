using UnityEngine;
public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T m_instance;

    public static T Inst
    {
        get
        {
            if (m_instance == null)
            {
                var singletonObject = new GameObject();
                m_instance = singletonObject.AddComponent<T>();
                singletonObject.name = typeof(T).ToString();
            }
            return m_instance;
        }
    }

    private void Awake()
    {
        _OnAwake();
    }

    private void Start()
    {
        _OnStart();
    }

    protected abstract void _OnAwake();
    protected abstract void _OnStart();
}
