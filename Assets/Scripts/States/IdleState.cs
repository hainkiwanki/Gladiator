using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Binki_Gladiator
{
    [CreateAssetMenu(fileName = "New State", menuName = "Gladiator/AbilityData/Idle")]
    public class IdleState : StateData
    {
        public override void UpdateAbility(CharacterState _state, Animator _animator)
        {
            if(InputManager.inputDirection != Vector2.zero)
            {
                _animator.SetBool("running", true);
                return;
            }
        }
    }
}
