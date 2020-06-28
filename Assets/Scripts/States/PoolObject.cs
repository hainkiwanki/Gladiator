using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Binki_Gladiator
{
    public class PoolObject : MonoBehaviour
    {
        public EPoolObjectType poolObjectType;
        public float scheduleOffTime;
        private Coroutine offRoutine;

        private void OnEnable()
        {
            if(offRoutine != null)
            {
                StopCoroutine(offRoutine);
            }

            if(scheduleOffTime > 0.0f)
                offRoutine = StartCoroutine(ScheduleOff());
        }

        public void TurnOff()
        {
            PoolManager.Inst.AddObject(this);
        }

        IEnumerator ScheduleOff()
        {
            yield return new WaitForSeconds(scheduleOffTime);

            if(!PoolManager.Inst.poolDictionary[poolObjectType].Contains(gameObject))
            {
                TurnOff();
            }
        }
    }
}
