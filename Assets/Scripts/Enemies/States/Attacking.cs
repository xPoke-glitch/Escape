using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : IState
{
    private Player _player;
    private Enemy _enemy;

    public Attacking(Player player, Enemy enemy)
    {
        _player = player;
        _enemy = enemy;
    }

    public void OnEnter()
    {
        if(_player.GetComponentInChildren<EquipSlot>().IsEquipped && _player.GetComponentInChildren<EquipSlot>().HasDurability)
        {
            // Player equipped with sword
            _enemy.DestroyEnemy();
            _player.GetComponentInChildren<EquipSlot>().GetCurrentEquipItem().GetComponent<DurabilityItem>().DecreaseDurability();
        }
        else
        {
            _player.Damage(1);
        }
    }

    public void OnExit()
    {
        // Nothing
    }

    public void Tick()
    {
        // Nothing
    }
}
