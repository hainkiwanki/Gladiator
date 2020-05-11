using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    #region AnimationEvents

    public delegate void OnAttackingFinished();
    public static OnAttackingFinished onAttackingFinished;

    #endregion
}
