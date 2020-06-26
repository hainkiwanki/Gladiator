using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Binki_Gladiator
{
    [CreateAssetMenu(fileName = "New State", menuName = "Gladiator/StateData/Attack")]
    public class AttackState : StateData
    {
        public override void OnEnter(CharacterState _state, AnimatorStateInfo _stateInfo, Animator _animator)
        {
        }

        public override void OnUpdate(CharacterState _state, AnimatorStateInfo _stateInfo, Animator _animator)
        {
        }

        public override void OnExit(CharacterState _state, AnimatorStateInfo _stateInfo, Animator _animator)
        {
            _animator.SetBool(ETransitionParam.AttackPrimary.ToString(), false);
        }

    }
}
