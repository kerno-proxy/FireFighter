using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(RandomColorGenerator))]
public class CubeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        RandomColorGenerator cube = (RandomColorGenerator)target;
        GUILayout.BeginHorizontal();
            if (GUILayout.Button("Generate Color"))
            {
                cube.GenerateColor();
            }
            if (GUILayout.Button("Reset Color"))
            {
                cube.Reset();
            }
        GUILayout.EndHorizontal();
    }
}
