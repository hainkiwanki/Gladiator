using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Binki_Gladiator
{
    public abstract class StateData : ScriptableObject
    {
        public float duration;
        public abstract void UpdateAbility(CharacterState _state, Animator _animator);
    }
}
