using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Binki_Gladiator
{
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
        public List<Collider> collidingParts = new List<Collider>();
        public Animator animator;

        private void Awake()
        {
            controller = GetComponent<CharacterController>();
            animator = GetComponent<Animator>();
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
            CharacterControl control = other.transform.root.GetComponent<CharacterControl>();

            if (control == null)
                return;

            if (other.gameObject == gameObject)
                return;

            if (!collidingParts.Contains(other))
            {
                Debug.Log(other.gameObject.name + " is colliding with " + gameObject.name);
                collidingParts.Add(other);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (collidingParts.Contains(other))
                collidingParts.Remove(other);
        }
    }
}