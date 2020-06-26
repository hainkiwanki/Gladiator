using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Binki_Gladiator
{
    public class CharacterState : StateMachineBehaviour
    {
        public List<StateData> transitionList = new List<StateData>();
        private CharacterControl m_characterControl;

        public CharacterControl GetCharacterControl(Animator _anim)
        {
            if (m_characterControl == null)
                m_characterControl = _anim.GetComponent<CharacterControl>();

            return m_characterControl;
        }

        public void UpdateAll(CharacterState _state, AnimatorStateInfo _stateInfo, Animator _anim)
        {
            foreach (StateData d in transitionList)
                d.OnUpdate(_state, _stateInfo, _anim);
        }


        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            UpdateAll(this, stateInfo, animator);
        }

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            foreach(StateData d in transitionList)
            {
                d.OnEnter(this, stateInfo, animator);
            }
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            foreach (StateData d in transitionList)
            {
                d.OnExit(this, stateInfo, animator);
            }
        }
    }
}
