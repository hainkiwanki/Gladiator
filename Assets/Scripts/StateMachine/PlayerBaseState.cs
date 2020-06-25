using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Binki_Gladiator
{
    public class PlayerBaseState : CharacterState
    {
        private PlayerController m_playerController;
        public PlayerController GetPlayerController(Animator _anim)
        {
            if (m_playerController == null)
                m_playerController = _anim.GetComponent<PlayerController>();

            return m_playerController;
        }

        public void UpdateAll(PlayerBaseState _state, Animator _anim)
        {
            foreach (StateData d in abilityDataList)
            {
                d.UpdateAbility(_state, _anim);
            }
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            UpdateAll(this, animator);
        }
    }
}
