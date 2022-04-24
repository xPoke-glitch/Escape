using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField]
    private Door door;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!door.IsOpen)
        {
            if (collision.gameObject.tag.Equals("Player"))
            {
                EquipSlot slot = collision.gameObject.GetComponentInChildren<EquipSlot>();
                if (slot.IsEquipped && slot.GetCurrentEquipItem().GetComponent<DroppableItem>().ItemName.Equals("Key"))
                {
                    slot.Unequip();
                    door.Open();
                }
            }
        }
    }
}
