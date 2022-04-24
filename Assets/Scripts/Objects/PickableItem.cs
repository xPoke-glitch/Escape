using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : MonoBehaviour, IPickable
{
    [SerializeField] 
    private GameObject droppablePrefab;

    public GameObject Pick()
    {
        Destroy(this.gameObject, 0.1f);
        return droppablePrefab;
    }
}
