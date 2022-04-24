using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Enemy), true)]
public class EnemyEditor : Editor
{
    private void OnSceneGUI()
    {
        Enemy enemy = (Enemy)target;
        Handles.color = Color.green;
        Handles.DrawWireArc(enemy.transform.position, Vector3.forward, Vector3.right, 360, enemy.TriggerRange);
        Handles.color = Color.blue;
        Handles.DrawWireArc(enemy.transform.position, Vector3.forward, Vector3.right, 360, enemy.CommunicationRange);
        Handles.color = Color.red;
        Handles.DrawWireArc(enemy.transform.position, Vector3.forward, Vector3.right, 360, enemy.HitRange);
    }
}
