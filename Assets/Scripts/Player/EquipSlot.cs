using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EquipSlot : MonoBehaviour
{
    public bool IsEquipped { get; private set; }
    public bool HasDurability { get; private set; }

    private SpriteRenderer _itemSprite;
    private GameObject _currentEquipItem;

    public GameObject GetCurrentEquipItem()
    {
        if (!IsEquipped)
            return null;
        return _currentEquipItem;
    }

    public void Equip(GameObject item)
    {
        _currentEquipItem = Instantiate(item, this.transform);
        IsEquipped = true;
        HasDurability = false;
    }

    public void Equip(GameObject item, int durability)
    {
        _currentEquipItem = Instantiate(item, this.transform);
        _currentEquipItem.GetComponent<DurabilityItem>().SetDurasbility(durability);
        IsEquipped = true;
        HasDurability = true;
    }

    public void Unequip()
    {
        if (!IsEquipped)
            return;
        _itemSprite = null;
        IsEquipped = false;
        HasDurability = false;

        Destroy(_currentEquipItem);
    }

    private void Drop()
    {
        if (!HasDurability)
            _currentEquipItem.GetComponent<DroppableItem>().Drop();
        else
            _currentEquipItem.GetComponent<DroppableItem>().Drop(
                _currentEquipItem.GetComponent<DurabilityItem>().GetDurability());

        _itemSprite = null;
        IsEquipped = false;
        HasDurability = false;
    }

    private void Awake()
    {
        IsEquipped = false;
        HasDurability = false;
    }

    private void Update()
    {
        if (IsEquipped && _itemSprite == null)
        {
            _itemSprite = GetComponentInChildren<SpriteRenderer>();
        }

        if(IsEquipped && _itemSprite != null)
        {
            if (InputManager.Instance.MoveDirection.Equals(Vector2.left) && !_itemSprite.flipX)
            {
                _itemSprite.flipX = true;
                this.transform.Translate(new Vector3(-2.0f, 0.0f, 0.0f));
            }
            else if (InputManager.Instance.MoveDirection.Equals(Vector2.right) && _itemSprite.flipX)
            {
                _itemSprite.flipX = false;
                this.transform.Translate(new Vector3(2.0f, 0.0f, 0.0f));
            }
        }

        if(_itemSprite == null)
        {
            this.transform.localPosition = new Vector3(1.0f, 0.2f, 0.0f);
        }

        if (IsEquipped && InputManager.Instance.GetDropItemPressed())
            Drop();

        if(IsEquipped && HasDurability && _currentEquipItem.GetComponent<DurabilityItem>().GetDurability() == 0)
        {
            Unequip();
            Destroy(_currentEquipItem);
        }
    }
}
