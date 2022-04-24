using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppableItem : MonoBehaviour, IDroppable
{
    public string ItemName { get {return itemName;} private set { itemName = value; } }

    [SerializeField]
    private string itemName;
    [SerializeField]
    private GameObject pickablePrefab;
    [SerializeField]
    private LayerMask collidingLayerMask;

    public void Drop()
    {
        Vector3 pos = GetFreePosition();

        Instantiate(pickablePrefab, pos, Quaternion.identity);

        Destroy(this.gameObject);
    }

    public void Drop(int durability)
    {
        Vector3 pos = GetFreePosition();

        GameObject obj = Instantiate(pickablePrefab, pos, Quaternion.identity);
        obj.GetComponent<DurabilityItem>().SetDurasbility(durability);

        Destroy(this.gameObject, 0.1f);
    }

    private void Awake()
    {
        ItemName = itemName;
    }

    private Vector3 GetFreePosition()
    {
        Vector3 basePos = this.transform.parent.parent.position;
        Vector3 upPos = new Vector3(basePos.x, basePos.y + 1.5f, basePos.z);
        Vector3 downPos = new Vector3(basePos.x, basePos.y - 1.5f, basePos.z);
        Vector3 rightPos = new Vector3(basePos.x + 1.5f, basePos.y, basePos.z);
        Vector3 leftPos = new Vector3(basePos.x - 1.5f, basePos.y, basePos.z);

        Collider2D colUp = Physics2D.OverlapCircle(upPos, 0.5f, collidingLayerMask);
        if (colUp == null)
        {
            //Debug.Log("[DroppableItem GetFreePosition]: UP FREE at " + upPos.ToString());
            return upPos;
        }

        Collider2D colRight = Physics2D.OverlapCircle(rightPos, 0.5f, collidingLayerMask);
        if (colRight == null)
        {
            //Debug.Log("[DroppableItem GetFreePosition]: RIGHT FREE at " + rightPos.ToString());
            return rightPos;
        }

        Collider2D colDown = Physics2D.OverlapCircle(downPos, 0.5f, collidingLayerMask);
        if (colDown == null)
        {
            //Debug.Log("[DroppableItem GetFreePosition]: DOWN FREE at " + downPos.ToString());
            return downPos;
        }

        Collider2D colLeft = Physics2D.OverlapCircle(leftPos, 0.5f, collidingLayerMask);
        if (colLeft == null)
        {
            //Debug.Log("[DroppableItem GetFreePosition]: LEFT FREE at " + leftPos.ToString());
            return leftPos;
        }

        return Vector3.zero;
    }
}
