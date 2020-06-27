using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Binki_Gladiator
{
    public class DamageDetector : MonoBehaviour
    {
        private CharacterControl m_control;

        private void Awake()
        {
            m_control = GetComponent<CharacterControl>();
        }

        private void Update()
        {
            if(AttackManager.Inst.currentAttacks.Count > 0)
            {
                CheckAttack();
            }
        }

        private void CheckAttack()
        {
            foreach(AttackInfo info in AttackManager.Inst.currentAttacks)
            {
                if (info == null || !info.isRegistered || info.isFinished)
                {
                    continue;
                }

                if (info.currentHits >= info.maxHits)
                {
                    continue;
                }

                if (info.attacker == m_control)
                {
                    continue;
                }

                if (info.mustCollide)
                {
                    if(IsCollided(info))
                    {
                        // Debug.Log("Did collide");
                        TakeDamage(info);
                    }
                }
            }
        }

        private bool IsCollided(AttackInfo _info)
        {
            foreach(Collider col in m_control.collidingParts)
            {
                foreach (string name in _info.colliderNames)
                {
                    if (col.gameObject.name == name)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void TakeDamage(AttackInfo _info)
        {
            // Debug.Log(_info.attacker.gameObject.name + " hits: " + gameObject.name);
            m_control.animator.runtimeAnimatorController = _info.attackState.GetDeathAnimator();
            _info.currentHits++;
        }
    }
}