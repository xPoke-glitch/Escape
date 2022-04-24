using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AstarPath))]
public class GraphUpdater : Singleton<GraphUpdater>
{
    private void OnEnable()
    {
        Door.OnDoorOpen += UpdateGraph;
        Door.OnDoorClose += UpdateGraph;
    }

    private void OnDisable()
    {
        Door.OnDoorOpen -= UpdateGraph;
        Door.OnDoorClose -= UpdateGraph;
    }

    private void UpdateGraph()
    {
        AstarPath.active.Scan();
    }
}
