using UnityEngine;
using System.Collections;

public class DemoDisplay : MonoBehaviour {

    public string text = "";
    public int width = 150;
    public int height = 150;


    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(5, 5, 250, 50));
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Demo 1"))
        {
            Application.LoadLevel(0);
        }
        if (GUILayout.Button("Demo 2"))
        {
            Application.LoadLevel(1);
        }
        if (GUILayout.Button("Demo 3"))
        {
            Application.LoadLevel(2);
        }
        if (GUILayout.Button("Demo 4"))
        {
            Application.LoadLevel(3);
        }
        GUILayout.EndHorizontal();
        GUILayout.EndArea();


        GUI.BeginGroup(new Rect(5, 40, width, height));

        GUI.Box(new Rect(0, 0, width, height), "Info");
        GUI.Label(new Rect(5, 15, width - 10, height - 15), text);

        GUI.EndGroup();

    }

}
