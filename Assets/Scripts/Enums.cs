using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EBehaviourState
{
    ENTER, EXECUTE, EXIT
}

public enum EButtonType
{ 
    LMB, RMB, F, W
}

public enum EUiElement
{
    InteractAlert,
}

public static class EnumExt
{
    public static string ToAnimationVariable(this EButtonType _type)
    {
        switch (_type)
        {
            default:
            case EButtonType.LMB:
                return "lmbclicks";
            case EButtonType.RMB:
                return "rmbclicks";
        }
    }
}