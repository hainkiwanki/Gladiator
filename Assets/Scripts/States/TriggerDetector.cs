using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Binki_Gladiator
{
    public class TriggerDetector : MonoBehaviour
    {
        public EGeneralBodyPart generalBodyPart;

        [SerializeField]
        private CharacterControl owner;
        public List<Collider> collidingParts = new List<Collider>();

        private void Awake()
        {
            owner = GetComponentInParent<CharacterControl>();
        }

        private void OnTriggerEnter(Collider col)
        {
            if (owner.ragdollParts.Contains(col))
            {
                return;
            }

            CharacterControl attacker = col.transform.root.GetComponent<CharacterControl>();

            if (attacker == null)
                return;

            if (col.gameObject == attacker.gameObject)
            {
                return;
            }

            // Debug.Log($"{owner.gameObject.name} collided with {gameObject.name}");
            if (!collidingParts.Contains(col))
            {
                collidingParts.Add(col);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (collidingParts.Contains(other))
                collidingParts.Remove(other);
        }
    }
}
