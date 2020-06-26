using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Binki_Gladiator
{

    [CreateAssetMenu(fileName = "New State", menuName = "Gladiator/StateData/Move")]
    public class MoveState : StateData
    {
        [SerializeField]
        private float m_inputDelay = 0.07f;
        private float m_startTime = 0.0f;
        private bool m_hasNoInput = false;

        [SerializeField]
        private bool m_automaticMovement = false;
        [SerializeField]
        private AnimationCurve m_speedCurve;
        [SerializeField]
        private float m_speed = 10.0f;

        public override void OnEnter(CharacterState _state, AnimatorStateInfo _stateInfo, Animator _animator)
        {

        }

        public override void OnUpdate(CharacterState _state, AnimatorStateInfo _stateInfo, Animator _animator)
        {
            CharacterControl control = _state.GetCharacterControl(_animator);

            if (!m_automaticMovement)
                ControlledMove(control, _stateInfo, _animator);
            else
                AutomaticMove(control, _stateInfo, _animator);

            if (control.isPrimaryAttack)
            {
                _animator.SetBool(ETransitionParam.AttackPrimary.ToString(), true);
            }

            m_hasNoInput = (InputManager.inputDirection == Vector2.zero);
            if (m_hasNoInput)
            {
                m_startTime += Time.deltaTime;
                if (m_startTime >= m_inputDelay)
                {
                    m_startTime = 0.0f;
                    _animator.SetBool(ETransitionParam.Running.ToString(), false);
                    return;
                }
            }
            else
                m_startTime = 0.0f;
        }

        private void ControlledMove(CharacterControl _control, AnimatorStateInfo _info, Animator _animator)
        {
            _control.Move(_control.direction, m_speed, m_speedCurve.Evaluate(_info.normalizedTime));
            _control.RotateForward();
        }

        private void AutomaticMove(CharacterControl _control, AnimatorStateInfo _info, Animator _animator)
        {
            _control.Move(_control.transform.forward, m_speed, m_speedCurve.Evaluate(_info.normalizedTime));
            _control.RotateForward();
        }

        public override void OnExit(CharacterState _state, AnimatorStateInfo _stateInfo, Animator _animator)
        {

        }
    }
}
