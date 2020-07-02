using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Binki_Gladiator
{
    [CreateAssetMenu(fileName = "SciptableObject", menuName = "Gladiator/Death/DeathAnimationData")]
    public class DeathAnimationData : ScriptableObject
    {
        public List<EGeneralBodyPart> generalBodyParts = new List<EGeneralBodyPart>();
        public RuntimeAnimatorController animator;
        public bool launchInAir;
        public bool isFacingAttacker;
    }
}