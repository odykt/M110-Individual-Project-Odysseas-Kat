// ----------------------------------------------------------------------------
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------
#if (UNITY_EDITOR) 

using UnityEditor;
using UnityEngine;



[CustomEditor(typeof(GameEventVariable), editorForChildClasses: true)]
public class EventEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUI.enabled = Application.isPlaying;

        GameEventVariable e = target as GameEventVariable;
        if (GUILayout.Button("Raise"))
            e.Raise();
    }
}
#endif