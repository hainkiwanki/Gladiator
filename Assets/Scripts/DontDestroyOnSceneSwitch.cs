using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnSceneSwitch : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
