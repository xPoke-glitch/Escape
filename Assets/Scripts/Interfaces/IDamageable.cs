using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public int MaxHealth { get; }
    public int Health { get; }
    public void Damage(int amount);
    public void Die();
}

