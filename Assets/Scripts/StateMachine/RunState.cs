using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Binki_Gladiator
{

    [CreateAssetMenu(fileName = "New State", menuName = "Gladiator/AbilityData/Run")]
    public class RunState : StateData
    {

        [SerializeField]
        private float m_inputDelay = 0.07f;
        private float m_startTime = 0.0f;
        private bool m_hasNoInput = false;

        public override void UpdateAbility(PlayerBaseState _state, Animator _animator)
        {
            PlayerController controller = _state.GetPlayerController(_animator);

            controller.Move(InputManager.inputDirection);

            m_hasNoInput = (InputManager.inputDirection == Vector2.zero);
            if (m_hasNoInput)
            {
                m_startTime += Time.deltaTime;
                if (m_startTime >= m_inputDelay)
                {
                    m_startTime = 0.0f;
                    _animator.SetBool("running", false);
                    return;
                }
            }
            else
                m_startTime = 0.0f;
        }
    }
}
