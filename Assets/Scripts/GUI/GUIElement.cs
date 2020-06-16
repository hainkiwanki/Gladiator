using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class GUIElement : MonoBehaviour
{
    public string id;
    private RectTransform m_rectTransform;
    [SerializeField]
    private Vector2 m_dir;
    [SerializeField]
    private float m_distance;

    private Vector2 m_endPos;
    private Vector2 m_beginPos;

    private void Awake()
    {
        OnAwake();
        m_rectTransform = (RectTransform)transform;
        m_endPos = m_rectTransform.anchoredPosition + m_dir * m_distance;
        m_beginPos = m_rectTransform.anchoredPosition;
    }

    public virtual void OnAwake() { }

    public void Show(bool _instant = false)
    {
        m_rectTransform.DOAnchorPos(m_endPos, 0.5f, true);
    }

    public void Hide(bool _instant = false)
    {
        m_rectTransform.DOAnchorPos(m_beginPos, 0.5f, true);
    }
}
