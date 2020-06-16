using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : Singleton<GUIManager>
{
    [SerializeField]
    private List<GUIElement> m_elements;
    private Transform m_canvas;
    private Dictionary<string, GUIElement> m_guiElements;

    protected override void _OnAwake()
    {
        m_canvas = GameObject.FindGameObjectWithTag("Canvas").transform;
        m_guiElements = new Dictionary<string, GUIElement>();
        foreach(var gui in m_elements)
        {
            m_guiElements.Add(gui.id, Instantiate(gui, m_canvas));
        }
    }

    protected override void _OnStart(){}

    public GUIElement CreateGUIElement(string _element)
    {
        if(!m_guiElements.ContainsKey(_element))
        {
            Debug.LogError("No such GUI element.");
            return null;
        }

        m_guiElements[_element].Show();
        return m_guiElements[_element];
    }

    public void RemoveGUIElement(string _element)
    {
        if (!m_guiElements.ContainsKey(_element))
        {
            Debug.Log("No such element created. Please confirm.");
            return;
        }

        m_guiElements[_element].Hide();
    }
}
