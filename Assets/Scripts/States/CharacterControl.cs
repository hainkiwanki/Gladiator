using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    [HideInInspector]
    public Vector3 direction;
    [HideInInspector]
    public CharacterController controller;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
}
