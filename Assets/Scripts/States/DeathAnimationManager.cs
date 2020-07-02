using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Binki_Gladiator
{
    public class DeathAnimationManager : Singleton<DeathAnimationManager>
    {
        private DeathAnimationLoader m_deathAnimationLoader;
        private List<RuntimeAnimatorController> m_candidates = new List<RuntimeAnimatorController>();

        protected override void _OnAwake() { }
        protected override void _OnStart() { }

        private void SetupDeathAnimationLoader()
        {
            if(m_deathAnimationLoader == null)
            {
                GameObject obj = Instantiate(Resources.Load<GameObject>("DeathAnimationLoader"));
                DeathAnimationLoader loader = obj.GetComponent<DeathAnimationLoader>();

                m_deathAnimationLoader = loader;
            }
        }

        public RuntimeAnimatorController GetAnimator(EGeneralBodyPart _bodyPart, AttackInfo _info)
        {
            SetupDeathAnimationLoader();

            m_candidates.Clear();

            foreach (DeathAnimationData data in m_deathAnimationLoader.deathAnimationDataList)
            {
                if (_info.launchInAir)
                {
                    if(data.launchInAir)
                    {
                        m_candidates.Add(data.animator);
                    }
                }
                else if(!_info.mustCollide)
                {
                    foreach (EGeneralBodyPart part in data.generalBodyParts)
                    {
                        // TODO: trigger some death animation
                        Debug.Log("Unimplemeted");
                    }
                }
                else
                {
                    foreach (EGeneralBodyPart part in data.generalBodyParts)
                    {
                        if (part == _bodyPart)
                        {
                            m_candidates.Add(data.animator);
                            break;
                        }
                    }
                }
            }

            return m_candidates[Random.Range(0, m_candidates.Count - 1)];
        }
    }
}