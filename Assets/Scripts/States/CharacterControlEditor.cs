using UnityEngine;
using UnityEditor;

namespace Binki_Gladiator
{
    [CustomEditor(typeof(CharacterControl))]
    public class CharacterControlEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            CharacterControl control = (CharacterControl)target;

            if(GUILayout.Button("Setup Ragdoll Parts"))
            {
                control.SetRagdollParts();
            }
        }
    }
}
