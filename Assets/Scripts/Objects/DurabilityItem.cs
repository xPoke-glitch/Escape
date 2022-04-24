using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DurabilityItem : MonoBehaviour
{
    [SerializeField]
    private int durability;

    public void SetDurasbility(int durability)
    {
        if (durability <= 0)
            return;
        this.durability = durability;
    }

    public int GetDurability()
    {
        return durability;
    }

    public void DecreaseDurability()
    {
        if (durability <= 0)
            return;
        durability--;
        /*if(durability == 0)
        {
            DestroyItem();
        }*/
    }

    private void DestroyItem()
    {
        // Play Animation or VFX here
        Destroy(this.gameObject);
    }
}
