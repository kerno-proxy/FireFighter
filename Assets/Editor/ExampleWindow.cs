using UnityEngine;
using UnityEditor;

public class ExampleWindow : EditorWindow
{
    Color color;
    [MenuItem("Window/Colorizer")]
    public static void ShowWindow()
    {
        GetWindow<ExampleWindow>("Colorizer");
    }
    private void OnGUI()
    {
        GUILayout.Label("Color the selected objects!", EditorStyles.boldLabel);

        color = EditorGUILayout.ColorField("Color", color);
        if (GUILayout.Button("Colorize"))
        {
            Colorize();

        }
        GUILayout.Button("TestButton");
    }

    private void Colorize()
    {
        foreach (GameObject objects in Selection.gameObjects)
        {
            Renderer renderer = objects.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.sharedMaterial.color = color;
            }
        }
    }
}
