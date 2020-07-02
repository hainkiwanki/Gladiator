using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Binki_Gladiator
{
    // Used when not coming from an attack => falling to attack
    [CreateAssetMenu(fileName = "New State", menuName = "Gladiator/StateData/CheckAttack")]
    public class CheckAttackState : StateData
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
            }
        }

        public override void OnExit(CharacterState _state, AnimatorStateInfo _stateInfo, Animator _animator)
        {
        }

    }
}
