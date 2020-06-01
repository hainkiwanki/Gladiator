using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerData
{
    public static PlayerController playerController
    {
        get { return m_playerController; }
        set { m_playerController = value; }
    }
    public static GameObject playerObject
    {
        get { return m_playerObject; }
        set
        {
            m_playerObject = value;
            if(m_playerController == null)
            {
                m_playerController = m_playerObject.GetComponentInChildren<PlayerController>();
            }
        }
    }

    private static GameObject m_playerObject;
    private static PlayerController m_playerController;
}
