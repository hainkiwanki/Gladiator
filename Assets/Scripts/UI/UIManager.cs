using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField]
    private RectTransform m_canvas;

    [SerializeField]
    private GameObject m_interactAlert;
    private GameObject m_currentInteractAlert;

    protected override void _OnAwake(){}

    protected override void _OnStart(){}


    public void ShowInteractAlert(string _key, bool _hide = false)
    {
        if (!_hide)
            Show(EUiElement.InteractAlert, _key);
        else
            Destroy(m_currentInteractAlert);
    }

    private void Show(EUiElement _element, params object[] _params)
    {
        switch (_element)
        {
            case EUiElement.InteractAlert:
                if(m_currentInteractAlert != null)
                {
                    Destroy(m_currentInteractAlert);
                }
                Debug.Log(_params[0]);
                m_currentInteractAlert = Instantiate(m_interactAlert, m_canvas);
                break;
            default:
                break;
        }
    }
}
