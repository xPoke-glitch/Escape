using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class DungeonLadder : MonoBehaviour
{
    [Header("Action")]
    [SerializeField]
    private UnityEvent onPlayerEnterAction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
            onPlayerEnterAction?.Invoke();
    }
}
