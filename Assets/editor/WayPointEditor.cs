using UnityEditor;
using UnityEngine;

namespace editor
{
    [InitializeOnLoad]
    public class WayPointEditor : MonoBehaviour
    {
        [DrawGizmo(GizmoType.NonSelected|GizmoType.Selected| GizmoType.Pickable)]
        public static void OnDrawSceneGizmos(WayPoint wayPoint, GizmoType gizmoType)
        {
            if ((gizmoType & GizmoType.Selected) != 0)
            {
                Gizmos.color = Color.red;
            }
            else
            {
                Gizmos.color = Color.red * .5f;
            }
            Gizmos.DrawSphere(wayPoint.transform.position,.1f);
            Gizmos.color = Color.white;
            Gizmos.DrawLine(wayPoint.transform.position + (wayPoint.transform.right * wayPoint.width / 2f), 
                wayPoint.transform.position - (wayPoint.transform.right * wayPoint.width / 2f));

            if (wayPoint.previousPoint != null)
            {
                Gizmos.color = Color.red;

                Vector3 offset = wayPoint.transform.right * wayPoint.width / 2;
                Vector3 offsetTo = wayPoint.previousPoint.transform.right * wayPoint.previousPoint.width / 2;
                Gizmos.DrawLine(wayPoint.transform.position + offset,wayPoint.previousPoint.transform.position + offsetTo);
                
            }
            
            if (wayPoint.nextPoint != null)
            {
                Gizmos.color = Color.green;

                Vector3 offset =  wayPoint.transform.right * -wayPoint.width / 2;
                Vector3 offsetTo =  wayPoint.nextPoint.transform.right * -wayPoint.nextPoint.width / 2;
                Gizmos.DrawLine(wayPoint.transform.position + offset, wayPoint.nextPoint.transform.position + offsetTo);
                
            }
            
        }
    }
}

