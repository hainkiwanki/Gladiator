using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Binki_Gladiator
{
    public class AttackManager : Singleton<AttackManager>
    {
        public List<AttackInfo> currentAttacks = new List<AttackInfo>();

        protected override void _OnAwake() { }
        protected override void _OnStart() { }
    }
}
