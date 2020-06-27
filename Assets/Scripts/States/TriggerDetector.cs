using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Binki_Gladiator
{
    public class TriggerDetector : MonoBehaviour
    {
        [SerializeField]
        private CharacterControl owner;

        private void Awake()
        {
            owner = GetComponentInParent<CharacterControl>();
        }

        private void OnTriggerEnter(Collider col)
        {
            CharacterControl attacker = col.transform.root.GetComponent<CharacterControl>();

            if (attacker == null)
                return;

            if (col.gameObject == attacker.gameObject)
            {
                return;
            }

            if (!owner.collidingParts.Contains(col))
            {
                owner.collidingParts.Add(col);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (owner.collidingParts.Contains(other))
                owner.collidingParts.Remove(other);
        }
    }
}
