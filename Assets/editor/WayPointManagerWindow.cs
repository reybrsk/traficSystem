using System;
using UnityEditor;
using UnityEngine;

namespace editor
{
    public class WayPointManagerWindow : EditorWindow
    {
        [MenuItem("Tools/WaypointEditor")]
        public static void Open()
        {
            GetWindow<WayPointManagerWindow>();
        }

        public Transform wayPointRoot;
        

        private void OnGUI()
        {
            
            SerializedObject obj = new SerializedObject(this);
            EditorGUILayout.PropertyField(obj.FindProperty($"wayPointRoot"));

            if (wayPointRoot == null)
            {
                EditorGUILayout.HelpBox("Root transform must be selected, Plese assign a root transform.", MessageType.Warning);
            }
            else
            {
                EditorGUILayout.BeginVertical("box");
                DrawButtons();
                EditorGUILayout.EndVertical();
            }

            obj.ApplyModifiedProperties();

        }

        private void DrawButtons()
        {
            if (GUILayout.Button("Create Waypoint"))
            {
                CreateWaypoint();
            }
        }

        private void CreateWaypoint()
        {
            GameObject waypointObject = new GameObject("Waypoint" + wayPointRoot.childCount, typeof(WayPoint));
            waypointObject.transform.SetParent(wayPointRoot,false);

            WayPoint wayPoint = waypointObject.GetComponent<WayPoint>();
            if (wayPointRoot.childCount > 1)
            {
                wayPoint.previousPoint = wayPointRoot.GetChild((wayPointRoot.childCount - 1) - 1).GetComponent<WayPoint>();
                wayPoint.previousPoint.nextPoint = wayPoint;            // следующая точка предыдущей точки  =  эта точка

                wayPoint.transform.position = wayPoint.previousPoint.transform.position;
                wayPoint.transform.forward = wayPoint.previousPoint.transform.forward;
            }

            Selection.activeGameObject = wayPoint.gameObject;
            
            
        }
    }
}
