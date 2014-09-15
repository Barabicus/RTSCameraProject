using UnityEngine;
using System.Collections;
using UnityEditor;

public class DemoControl : MonoBehaviour {

    int width = 300, height = 400;
    bool behaviourFoldout = false;
    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, width, height));

        GUI.Box(new Rect(0, 0, width, height), "");

        behaviourFoldout = GUILayout.Toggle(behaviourFoldout, "FF", EditorStyles.foldout);

        GUILayout.EndArea();
    }

}
