using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : Singleton<GUIManager>
{

    private List<GUIElement> m_guiElements;

    protected override void _OnAwake()
    {
        m_guiElements = new List<GUIElement>();
    }

    protected override void _OnStart(){}

    public void RegisterElement(GUIElement _element)
    {
        if (m_guiElements.Contains(_element)) return;

        m_guiElements.Add(_element);
    }
}
