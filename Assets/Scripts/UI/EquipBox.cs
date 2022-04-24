using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipBox : MonoBehaviour
{
    [Header("EquipSlot")]
    [SerializeField]
    private EquipSlot equipSlot;

    [Header("UI")]
    [SerializeField]
    private Image itemIcon;
    [SerializeField]
    private TextMeshProUGUI durabilityText;

    private void Update()
    {
        if (equipSlot.IsEquipped || equipSlot.GetCurrentEquipItem() != null)
        {
            itemIcon.color = Color.white;
            if (equipSlot.GetCurrentEquipItem() != null)
            {
                itemIcon.sprite = equipSlot.GetCurrentEquipItem().GetComponent<UIItem>().GetIcon();
            }

            if (equipSlot.HasDurability)
            {
                durabilityText.text = "Dur " + equipSlot.GetCurrentEquipItem().GetComponent<DurabilityItem>().GetDurability();
            }
            else
            {
                durabilityText.text = "Dur NONE";
            }
        }
        else
        {
            itemIcon.color = Color.black;
            itemIcon.sprite = null;
            durabilityText.text = "No Item";
        }
    }
}
