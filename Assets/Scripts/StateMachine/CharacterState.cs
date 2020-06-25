using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Binki_Gladiator
{
    public class CharacterState : StateMachineBehaviour
    {
        public List<StateData> abilityDataList = new List<StateData>();
        private CharacterController m_characterController;
        public CharacterController GetCharacterController(Animator _anim)
        {
            if (m_characterController == null)
                m_characterController = _anim.GetComponent<CharacterController>();

            return m_characterController;
        }
    }
}
