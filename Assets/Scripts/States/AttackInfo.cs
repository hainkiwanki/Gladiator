using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Binki_Gladiator
{
    public class AttackInfo : MonoBehaviour
    {
        public CharacterControl attacker = null;
        public AttackState attackState;
        public List<string> colliderNames = new List<string>();

        public bool mustCollide;
        public bool mustFaceAttacker;
        public float lethalRange;
        public int maxHits;
        public int currentHits;
        public bool isRegistered;
        public bool isFinished;

        public void ResetInfo(AttackState _attack, CharacterControl _attacker)
        {
            isRegistered = false;
            isFinished = false;
            attackState = _attack;
            attacker = _attacker;
        }

        public void Register(AttackState _attack)
        {
            isRegistered = true;

            attackState = _attack;
            colliderNames = _attack.colliderNames;
            mustCollide = _attack.mustCollide;
            mustFaceAttacker = _attack.mustFaceAttacker;
            lethalRange = _attack.lethalRange;
            maxHits = _attack.maxHits;
            currentHits = 0;
        }

        private void OnDisable()
        {
            isFinished = true;
        }
    }
}