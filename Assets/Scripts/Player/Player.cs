using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour, IDamageable
{
    public static event Action OnDamage;
    public static event Action OnGameOver;

    public int MaxHealth { get; private set; }

    public int Health { get; private set; }

    [Header("Stats")]
    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private int health;
   
    public void Damage(int amount)
    {
        if (amount <= 0)
            return;
        if (Health <= 0)
            return;

        Health--;

        if (Health <= 0)
            Die();
        else
        {
            OnDamage?.Invoke();
            PlayerPrefs.SetInt("health", Health);
        }
            
    }

    public void Die()
    {
        Debug.Log("Player Dead - GameOver");
        PlayerPrefs.DeleteAll();
        OnGameOver?.Invoke();
    }

    private void Awake()
    {
        if (PlayerPrefs.GetInt("health") != 0)
        {
            health = PlayerPrefs.GetInt("health");
        }
        Health = health;
        MaxHealth = maxHealth;
    }

    
}
