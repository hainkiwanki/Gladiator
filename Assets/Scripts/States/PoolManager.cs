using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Binki_Gladiator
{
    public class PoolManager : Singleton<PoolManager>
    {
        public Dictionary<EPoolObjectType, List<GameObject>> poolDictionary = new Dictionary<EPoolObjectType, List<GameObject>>();

        protected override void _OnAwake() { }
        protected override void _OnStart() { }

        public void SetUpDictionary()
        {
            EPoolObjectType[] arr = System.Enum.GetValues(typeof(EPoolObjectType)) as EPoolObjectType[];

            foreach(EPoolObjectType p in arr)
            {
                if(!poolDictionary.ContainsKey(p))
                {
                    poolDictionary.Add(p, new List<GameObject>());
                }
            }
        }

        public GameObject GetObject(EPoolObjectType _type)
        {
            if (poolDictionary.Count == 0)
                SetUpDictionary();

            List<GameObject> list = poolDictionary[_type];
            GameObject obj = null;

            if(list.Count > 0)
            {
                obj = list[0];
                list.RemoveAt(0);
            }
            else
            {
                obj = PoolObjectLoader.InstantiatePrefab(_type).gameObject;
            }

            return obj;
        }

        public void AddObject(PoolObject _obj)
        {
            List<GameObject> list = poolDictionary[_obj.poolObjectType];
            list.Add(_obj.gameObject);
            _obj.gameObject.SetActive(false);
        }
    }
}