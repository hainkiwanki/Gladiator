using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    #region AnimationEvents
    public delegate void OnAttackComboReady(int _i);
    public static OnAttackComboReady onAttackComboReady;


    public delegate void OnIdleAnimation();
    public static OnIdleAnimation onIdleAnimationEntered;
    #endregion
}
