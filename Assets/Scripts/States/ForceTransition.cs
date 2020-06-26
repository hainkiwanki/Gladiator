using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Binki_Gladiator
{
    [CreateAssetMenu(fileName = "New State", menuName = "Gladiator/StateData/Force")]
    public class ForceTransition : StateData
    {
        [Range(0.01f, 1.0f)]
        public float transitionTime;

        public override void OnEnter(CharacterState _state, AnimatorStateInfo _stateInfo, Animator _animator)
        {

        }
        public override void OnUpdate(CharacterState _state, AnimatorStateInfo _stateInfo, Animator _animator)
        {
            if(_stateInfo.normalizedTime >= transitionTime)
            {
                _animator.SetBool(ETransitionParam.ForceTransition.ToString(), true);
            }
        }

        public override void OnExit(CharacterState _state, AnimatorStateInfo _stateInfo, Animator _animator)
        {
            _animator.SetBool(ETransitionParam.ForceTransition.ToString(), false);
        }

    }
}
