using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Binki_Gladiator
{
    [CreateAssetMenu(fileName = "New State", menuName = "Gladiator/StateData/Attack")]
    public class AttackState : StateData
    {
        public bool debug = false;

        public float startAttackTime, endAttackTime;
        public List<string> colliderNames = new List<string>();
        public bool lauchIntoAir;
        public bool mustCollide;
        public bool mustFaceAttacker;
        public float lethalRange;
        public int maxHits;

        private List<AttackInfo> finishedAttacks = new List<AttackInfo>();

        public override void OnEnter(CharacterState _state, AnimatorStateInfo _stateInfo, Animator _animator)
        {
            _animator.SetBool(ETransitionParam.AttackPrimary.ToString(), false);

            GameObject obj = PoolManager.Inst.GetObject(EPoolObjectType.ATTACKINFO);
            AttackInfo info = obj.GetComponent<AttackInfo>();

            obj.SetActive(true);
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
            CheckCombo(_state, _stateInfo, _animator);
        }

        public void RegisterAttack(CharacterState _state, AnimatorStateInfo _stateInfo, Animator _animator)
        {
            if (startAttackTime <= _stateInfo.normalizedTime && endAttackTime >= _stateInfo.normalizedTime)
            {
                foreach (AttackInfo info in AttackManager.Inst.currentAttacks)
                {
                    if (info == null)
                        continue;

                    if (!info.isRegistered && info.attackState == this)
                    {
                        if(debug)
                        {
                            Debug.Log(name + " registered " + _stateInfo.normalizedTime);
                        }
                        info.Register(this);
                    }
                }
            }
        }

        public void DeregisterAttack(CharacterState _state, AnimatorStateInfo _stateInfo, Animator _animator)
        {
            if (_stateInfo.normalizedTime >= endAttackTime)
            {
                foreach (AttackInfo info in AttackManager.Inst.currentAttacks)
                {
                    if (info == null)
                        continue;

                    if (info.attackState == this && !info.isFinished)
                    {
                        if (debug)
                        {
                            Debug.Log(name + " deregistered " + _stateInfo.normalizedTime);
                        }

                        info.isFinished = true;
                        info.GetComponent<PoolObject>().TurnOff();
                    }
                }
            }
        }

        public void CheckCombo(CharacterState _state, AnimatorStateInfo _stateInfo, Animator _animator)
        {
            if(_stateInfo.normalizedTime >= startAttackTime + ((endAttackTime - startAttackTime) / 3.0f))
            {
                if(_stateInfo.normalizedTime < endAttackTime + ((endAttackTime - startAttackTime) / 2.0f))
                {
                    CharacterControl control = _state.GetCharacterControl(_animator);
                    if(control.isPrimaryAttack)
                    {
                        Debug.Log("next chain combo");
                        _animator.SetBool(ETransitionParam.AttackPrimary.ToString(), true);
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
            finishedAttacks.Clear();
            foreach(AttackInfo info in AttackManager.Inst.currentAttacks)
            {
                if(info == null || info.attackState == this /* info.isFinished */)
                {
                    finishedAttacks.Add(info);
                }
            }

            foreach(AttackInfo info in finishedAttacks)
            {
                if(AttackManager.Inst.currentAttacks.Contains(info))
                {
                    AttackManager.Inst.currentAttacks.Remove(info);
                }
            }
        }
    }
}
