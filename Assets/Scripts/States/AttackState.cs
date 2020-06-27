using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Binki_Gladiator
{
    [CreateAssetMenu(fileName = "New State", menuName = "Gladiator/StateData/Attack")]
    public class AttackState : StateData
    {
        public float startAttackTime, endAttackTime;
        public List<string> colliderNames = new List<string>();
        public bool mustCollide;
        public bool mustFaceAttacker;
        public float lethalRange;
        public int maxHits;
        public List<RuntimeAnimatorController> deathAnimators = new List<RuntimeAnimatorController>();

        public override void OnEnter(CharacterState _state, AnimatorStateInfo _stateInfo, Animator _animator)
        {
            _animator.SetBool(ETransitionParam.AttackPrimary.ToString(), false);

            GameObject obj = Instantiate(Resources.Load<GameObject>("AttackInfo"));
            AttackInfo info = obj.GetComponent<AttackInfo>();
            info.ResetInfo(this, _state.GetCharacterControl(_animator));

            if (!AttackManager.Inst.currentAttacks.Contains(info))
                AttackManager.Inst.currentAttacks.Add(info);

            CharacterControl control = _state.GetCharacterControl(_animator);
            control.RotateToMousePosition();
        }

        public override void OnUpdate(CharacterState _state, AnimatorStateInfo _stateInfo, Animator _animator)
        {
            RegisterAttack(_state, _stateInfo, _animator);
            DeregisterAttack(_state, _stateInfo, _animator);
        }

        public void RegisterAttack(CharacterState _state, AnimatorStateInfo _stateInfo, Animator _animator)
        {
            if(startAttackTime <= _stateInfo.normalizedTime && endAttackTime >= _stateInfo.normalizedTime)
            {
                foreach(AttackInfo info in AttackManager.Inst.currentAttacks)
                {
                    if (info == null)
                        continue;

                    if(!info.isRegistered && info.attackState == this)
                    {
                        info.Register(this);
                    }
                }
            }
        }

        public void DeregisterAttack(CharacterState _state, AnimatorStateInfo _stateInfo, Animator _animator)
        {
            if(_stateInfo.normalizedTime >= endAttackTime)
            {
                foreach(AttackInfo info in AttackManager.Inst.currentAttacks)
                {
                    if (info == null)
                        continue;

                    if(info.attackState == this && !info.isFinished)
                    {
                        info.isFinished = true;
                        Destroy(info.gameObject);
                    }
                }
            }
        }

        public override void OnExit(CharacterState _state, AnimatorStateInfo _stateInfo, Animator _animator)
        {
            ClearAttack();
        }

        public void ClearAttack()
        {
            for (int i = 0; i < AttackManager.Inst.currentAttacks.Count; i++)
            {
                if(AttackManager.Inst.currentAttacks[i] == null || AttackManager.Inst.currentAttacks[i].isFinished)
                {
                    AttackManager.Inst.currentAttacks.RemoveAt(i);
                }
            }
        }

        public RuntimeAnimatorController GetDeathAnimator()
        {
            int index = Random.Range(0, deathAnimators.Count);
            return deathAnimators[index];
        }
    }
}
