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

        [SerializeField]
        private float m_speed = 10.0f;
        [SerializeField]
        private float m_rotationSpeed = 8.0f;

        public override void UpdateAbility(CharacterState _state, Animator _animator)
        {
            CharacterControl control = _state.GetCharacterControl(_animator);

            control.controller.Move(control.direction * Time.deltaTime * m_speed);
            if (control.direction != Vector3.zero)
            {
                Quaternion targetRot = Quaternion.LookRotation(control.direction);
                control.transform.rotation = Quaternion.Slerp(control.transform.rotation, targetRot, m_rotationSpeed * Time.deltaTime);
            }

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
