using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(HeartBeat))]
public class HeartBeatInspector : Editor
{
    public override void OnInspectorGUI()
    {

        GUILayout.Label("Object dynamic size!");
        HeartBeat heartBeat = (HeartBeat)target;
        heartBeat.baseSize=EditorGUILayout.Slider("Size",heartBeat.baseSize, .1f, 2f);
        heartBeat.transform.localScale = Vector3.one * heartBeat.baseSize;
    }
}
