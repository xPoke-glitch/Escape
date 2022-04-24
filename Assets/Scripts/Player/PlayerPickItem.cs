using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerPickItem : MonoBehaviour
{
    [SerializeField]
    private EquipSlot equipSlot;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PickableItem item = null;
        if (collision.gameObject.TryGetComponent(out item))
        {
            if (!equipSlot.IsEquipped)
            {
                GameObject pickedItem = item.Pick();

                DurabilityItem dur = null;
                if (item.TryGetComponent(out dur))
                {
                    equipSlot.Equip(pickedItem, dur.GetDurability());
                }
                else
                {
                    equipSlot.Equip(pickedItem);
                }
            }
        }
    }
}
