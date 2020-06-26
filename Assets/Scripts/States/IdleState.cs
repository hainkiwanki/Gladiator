using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Binki_Gladiator
{
    [CreateAssetMenu(fileName = "New State", menuName = "Gladiator/StateData/Idle")]
    public class IdleState : StateData
    {
        public override void OnEnter(CharacterState _state, AnimatorStateInfo _stateInfo, Animator _animator)
        {
        }

        public override void OnUpdate(CharacterState _state, AnimatorStateInfo _stateInfo, Animator _animator)
        {
            CharacterControl control = _state.GetCharacterControl(_animator);
            if (control.isPrimaryAttack)
            {
                _animator.SetBool(ETransitionParam.AttackPrimary.ToString(), true);
                return;
            }

            if (control.direction != Vector3.zero)
            {
                _animator.SetBool(ETransitionParam.Running.ToString(), true);
                return;
            }
        }

        public override void OnExit(CharacterState _state, AnimatorStateInfo _stateInfo, Animator _animator)
        {
        }

    }
}
