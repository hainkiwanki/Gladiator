using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Binki_Gladiator
{
    public class PoolObjectLoader : MonoBehaviour
    {
        public static PoolObject InstantiatePrefab(EPoolObjectType _objType)
        {
            GameObject obj = null;

            switch (_objType)
            {
                case EPoolObjectType.ATTACKINFO:
                    obj = Instantiate(Resources.Load<GameObject>("AttackInfo"));
                    break;
                default:
                    break;
            }

            return obj.GetComponent<PoolObject>();
        }
    }
}