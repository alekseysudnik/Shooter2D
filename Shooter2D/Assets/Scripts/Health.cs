using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
   [SerializeField]
    private int maxHealth;
    private int health;
    public event EventHandler OnDeath;
    public event EventHandler<onHealthChangedArgs> OnHealthChanged;
    public class onHealthChangedArgs : EventArgs
    { 
        public float healthToPass { get; set; }
    }

    private void Start()
    {
        health = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health > 0)
        {
            OnHealthChanged(this, new onHealthChangedArgs { healthToPass = (float)health / maxHealth });
        }
        else
        {
            Die();
        }
    }

    private void Die()
    {
        OnDeath(this, EventArgs.Empty);
        Destroy(gameObject);
    }

}
