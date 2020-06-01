using Knife.HDRPOutline.Core;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    protected OutlineObject m_outlineObject;
    [SerializeField]
    protected float m_interactRadius = 2.0f;
    [SerializeField]
    protected Vector3 m_interactOffset = Vector3.zero;
    protected SphereCollider m_collider;

    private void Awake()
    {
        m_outlineObject = GetComponentInChildren<OutlineObject>();
        m_outlineObject.enabled = false;

        m_collider = gameObject.AddComponent<SphereCollider>();
        m_collider.center = m_interactOffset;
        m_collider.radius = m_interactRadius;
        m_collider.isTrigger = true;
    }

    [ExecuteInEditMode]
    private void OnDrawGizmos()
    {
        var col = Color.green;
        col.a = 0.5f;
        Gizmos.color = col;
        Gizmos.DrawSphere(transform.position + m_interactOffset, m_interactRadius);
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.tag != "Player")
            return;

        m_outlineObject.enabled = true;
        UIManager.Inst?.ShowInteractAlert("F");
    }

    private void OnTriggerExit(Collider _other)
    {
        if (_other.tag != "Player")
            return;

        UIManager.Inst?.ShowInteractAlert("F", true);
        m_outlineObject.enabled = false;
    }
}
