using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;

public class Unity_Assistent : EditorWindow
{
    GameObject selectedObject;
    bool settings, objectSettings; //Top Horizontal Buttons
    bool change_Color; //Button Options
    bool objectInfo, objectComponents, objectQuikChanges; //ObjectSettings Options
    bool objectComponents3D; //Component Filter

    bool loadFilter = false;

    string searchComponent = "";
    string[] searchComponents = new string[5];
    string[] searchComponentsTag = new string[5];

    Vector3 pos, size;
    Vector2 scrollPos;

    Color matColor = Color.white;


    [MenuItem("Window/Unity_Assistent")]
    static void Init()
    {
        Unity_Assistent assist = (Unity_Assistent)EditorWindow.GetWindow(typeof(Unity_Assistent));
        assist.autoRepaintOnSceneChange = true;
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
            //Object Settings
            GUILayout.BeginHorizontal("box");
            GUILayout.BeginVertical("box");
            GUILayout.Label("Object Settings", EditorStyles.boldLabel);
            //enableBool = EditorGUILayout.Toggle("Test Bool", enableBool);
            selectedObject = (GameObject)EditorGUILayout.ObjectField(selectedObject, typeof(GameObject));

            GUILayout.EndVertical();
            GUILayout.EndHorizontal();

            scrollPos = GUILayout.BeginScrollView(scrollPos, GUILayout.Width(position.width), GUILayout.Height(position.height - 100));
            //Object Info
            GUILayout.BeginVertical("Box");
            if (GUILayout.Button("Object Info"))
            {
                objectInfo = !objectInfo;
            }
            if (objectInfo)
            {
                GUILayout.Label("Object Info", EditorStyles.boldLabel);
                GUILayout.Label("Name: " + selectedObject.transform.name.ToString());
                GUILayout.Label("Position: " + selectedObject.transform.position.ToString());
                GUILayout.Label("Size: " + selectedObject.transform.localScale.ToString());
            }
            GUILayout.EndVertical();
            //Object Quik Change
            GUILayout.BeginVertical("Box");
            if (GUILayout.Button("Object Change"))
            {
                objectQuikChanges = !objectQuikChanges;
            }
            if (objectQuikChanges)
            {
                GUILayout.Label("Object Changes", EditorStyles.boldLabel);
                matColor = EditorGUILayout.ColorField("New Color", matColor);
            }
            GUILayout.EndVertical();

            //Object Components
            GUILayout.BeginVertical("Box");
            if (GUILayout.Button("Object Components"))
            {
                objectComponents = !objectComponents;
            }
            if (objectComponents)
            {
                //3D
                if (GUILayout.Button("3D"))
                {
                    objectComponents3D = !objectComponents3D;
                }
            if (objectComponents3D)
                {
                    //Search Component
                    searchComponent = EditorGUILayout.TextField("Search: ", searchComponent);

                    //Begin Physics
                    GUILayout.BeginVertical("Box");
                    GUILayout.Label("Tag", EditorStyles.boldLabel);
                    for (int i = 0; i < searchComponents.Length; i++)
                    {
                        if (string.IsNullOrEmpty(searchComponent) || searchComponents[i].ToLower().Contains(searchComponent.ToLower()))
                        {
                            if (searchComponentsTag[i] == "Tag")
                            {
                                GetComponents(searchComponents[i]);
                            }
                        }
                    }
                    GUILayout.EndVertical();
                    //Begin Colliders
                    GUILayout.BeginVertical("Box");
                    GUILayout.Label("Colliders", EditorStyles.boldLabel);
                    for (int i = 0; i < searchComponents.Length; i++)
                    {
                        if (string.IsNullOrEmpty(searchComponent) || searchComponents[i].ToLower().Contains(searchComponent.ToLower()))
                        {
                            if (searchComponentsTag[i] == "Colliders")
                            {
                                GetComponents(searchComponents[i]);
                            }
                        }
                    }
                    GUILayout.EndVertical();


                }
            }
            GUILayout.EndVertical();







            GUILayout.EndScrollView();
        }
    }

    void Update()
    {
        //Set Filter
        if (!loadFilter)
        {
            SetFilter();
        }

        selectedObject = Selection.activeGameObject;
    }

    void GetComponents(string name)
    {
        if (selectedObject.GetComponent(name) != null)
        { GUI.backgroundColor = new Color(0, 1, 0, 0.85f); }
        else
        { GUI.backgroundColor = new Color(1f, 0, 0, 0.5f); }
        if (GUILayout.Button(name.ToString()))
        {
            if (selectedObject.GetComponent(name) != null)
            { DestroyImmediate(selectedObject.GetComponent(name)); }
            else
            {
                //Physics
                if (name == "Rigidbody") { selectedObject.AddComponent<Rigidbody>();}
                if (name == "CharacterController") { selectedObject.AddComponent<CharacterController>();}
                //Colliders
                if (name == "BoxCollider") { selectedObject.AddComponent<BoxCollider>();}
                if (name == "MeshCollider") { selectedObject.AddComponent<MeshCollider>(); }
                if (name == "SphereCollider") { selectedObject.AddComponent<SphereCollider>(); }
            }
        }
        GUI.backgroundColor = new Color(1, 1, 1, 1);
    }

    void SetFilter()
    {
        loadFilter = true;
        //Components
        searchComponents[0] = "Rigidbody";
        searchComponents[1] = "CharacterController";
        searchComponents[2] = "BoxCollider";
        searchComponents[3] = "MeshCollider";
        searchComponents[4] = "SphereCollider";
        //Tags
        searchComponentsTag[0] = "Tag";
        searchComponentsTag[1] = "Tag";
        searchComponentsTag[2] = "Colliders";
        searchComponentsTag[3] = "Colliders";
        searchComponentsTag[4] = "Colliders";

    }
}

//GUILayout.Toolbar