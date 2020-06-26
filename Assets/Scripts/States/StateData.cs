using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Binki_Gladiator
{
    public abstract class StateData : ScriptableObject
    {
        public abstract void OnEnter(CharacterState _state, AnimatorStateInfo _stateInfo, Animator _animator);
        public abstract void OnUpdate(CharacterState _state, AnimatorStateInfo _stateInfo, Animator _animator);
        public abstract void OnExit(CharacterState _state, AnimatorStateInfo _stateInfo, Animator _animator);
        
    }
}
