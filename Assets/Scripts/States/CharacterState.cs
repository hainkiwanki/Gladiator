using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Binki_Gladiator
{
    public class CharacterState : StateMachineBehaviour
    {
        public List<StateData> abilityDataList = new List<StateData>();
        private CharacterControl m_characterControl;
        public CharacterControl GetCharacterControl(Animator _anim)
        {
            if (m_characterControl == null)
                m_characterControl = _anim.GetComponent<CharacterControl>();

            return m_characterControl;
        }

        public void UpdateAll(CharacterState _state, Animator _anim)
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

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }
    }
}
