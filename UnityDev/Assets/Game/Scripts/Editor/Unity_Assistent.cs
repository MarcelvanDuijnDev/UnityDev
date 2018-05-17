using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Unity_Assistent : EditorWindow 
{
    GameObject selectedObject;
    bool settings, objectSettings;


    [MenuItem("Window/Unity_Assistent")]
    static void Init()
    {
        Unity_Assistent assist = (Unity_Assistent)EditorWindow.GetWindow(typeof(Unity_Assistent));
        assist.Show();
    }

    void OnGUI()
    {
        GUILayout.BeginHorizontal("box");
        if (GUILayout.Button("Obj Settings"))
        {
            objectSettings = !objectSettings;
        }
        if (GUILayout.Button("Settings"))
        {
            settings = !settings;
        }
        GUILayout.EndHorizontal();

        if (objectSettings)
        {
            GUILayout.Label("Object Settings", EditorStyles.boldLabel);
            //enableBool = EditorGUILayout.Toggle("Test Bool", enableBool);
            selectedObject = (GameObject)EditorGUILayout.ObjectField(selectedObject, typeof(GameObject));
        }
    }

    void Update()
    {
        selectedObject = Selection.activeGameObject;
    }
}
