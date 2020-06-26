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

        public void ResetInfo(AttackState _attack)
        {
            isRegistered = false;
            isFinished = false;
            attackState = _attack;
        }

        public void Register(AttackState _attack, CharacterControl _attacker)
        {
            isRegistered = true;
            attacker = _attacker;

            attackState = _attack;
            colliderNames = _attack.colliderNames;
            mustCollide = _attack.mustCollide;
            mustFaceAttacker = _attack.mustFaceAttacker;
            lethalRange = _attack.lethalRange;
            maxHits = _attack.maxHits;
            currentHits = 0;
        }
    }
}