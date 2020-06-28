using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Binki_Gladiator
{
    public class CharacterControl : MonoBehaviour
    {
        [HideInInspector]
        public Vector3 direction;
        public Vector3 mousePosition;
        [HideInInspector]
        public CharacterController controller;
        public bool isHoldingWeapon;
        public bool isPrimaryAttack;
        public bool isSecondaryAttack;
        public float rotationSpeed = 8.0f;
        // public List<Collider> collidingParts = new List<Collider>();
        public List<Collider> ragdollParts = new List<Collider>();
        public Animator animator;

        private List<TriggerDetector> triggerDetectors = new List<TriggerDetector>();

        private void Awake()
        {
            controller = GetComponent<CharacterController>();
            animator = GetComponent<Animator>();
            // SetRagdollParts();
        }

        public List<TriggerDetector> GetAllTriggers()
        {
            if(triggerDetectors.Count == 0)
            {
                TriggerDetector[] arr = gameObject.GetComponentsInChildren<TriggerDetector>();
                triggerDetectors.AddRange(arr);
            }

            return triggerDetectors;
        }

        public void SetRagdollParts()
        {
            ragdollParts.Clear();

            Collider[] colliders = gameObject.GetComponentsInChildren<Collider>();
            foreach(Collider c in colliders)
            {
                if (c.gameObject != gameObject)
                {
                    c.isTrigger = true;
                    ragdollParts.Add(c);
                    if (c.GetComponent<TriggerDetector>() == null)
                    {
                        c.gameObject.AddComponent<TriggerDetector>();
                    }
                }
            }
        }

        public void EnableRagdoll()
        {
            gameObject.GetComponent<CharacterController>().enabled = false;
            animator.enabled = false;
            animator.avatar = null;
            // TODO: Rigidbody for interactions

            foreach(Collider c in ragdollParts)
            {
                c.isTrigger = false;
            }
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

        public void RotateToMousePosition()
        {
            Quaternion targetRot = Quaternion.LookRotation(mousePosition - transform.position);
            transform.rotation = targetRot;
        }
    }
}