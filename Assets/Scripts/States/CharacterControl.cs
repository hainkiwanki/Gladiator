using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    [HideInInspector]
    public Vector3 direction;
    [HideInInspector]
    public CharacterController controller;
    public bool isHoldingWeapon;
    public bool isPrimaryAttack;
    public bool isSecondaryAttack;
    public float rotationSpeed = 8.0f; 

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    public void Move(Vector3 _direction, float _speed, float _speedCurve)
    {
        controller.Move(_direction * _speed * _speedCurve * Time.deltaTime);
    }

    public void RotateForward()
    {
        if (direction != Vector3.zero)
        {
            Quaternion targetRot = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
