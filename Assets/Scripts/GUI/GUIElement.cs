using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GUIElement : MonoBehaviour
{
    public string id;

    private void Awake()
    {
        Register();
        OnAwake();
    }

    private void OnEnable()
    {
        Hide();
    }

    public virtual void OnAwake() { }

    public abstract void Show();
    public abstract void Hide();

    protected virtual void Register()
    {
        GUIManager.Inst?.RegisterElement(this);
    }
}
