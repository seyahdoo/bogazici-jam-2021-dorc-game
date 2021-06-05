using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Bot))]
public class BotEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        if (GUILayout.Button("Start Following")) {
            ((Bot)target).StartFollowing();
        }
    }
}
