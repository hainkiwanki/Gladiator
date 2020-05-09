using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    private void Awake()
    {
        InputManager.Awake();
    }

    private void OnEnable()
    {
        InputManager.OnEnable();
    }

    private void OnDisable()
    {
        InputManager.OnDisable();
    }

    private void Update()
    {
        InputManager.Update();
    }
}
