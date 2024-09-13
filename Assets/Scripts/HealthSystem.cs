using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float maxHP;
    private float currentHP;

    public event EventHandler OnHPChanged;
    public event EventHandler OnDie;
    public static event EventHandler<DamageEventArgs> OnAnyUnitDamaged;

    public class DamageEventArgs : EventArgs
    {
        public float damageAmount;
        public Vector2 damagedPoint;
    }

    private void OnEnable()
    {
        currentHP = maxHP;
        OnHPChanged?.Invoke(this, EventArgs.Empty);
    }

    public void Damage(float amount)
    {
        Debug.Log("Damage " + amount);
        currentHP -= amount;

        DamageEventArgs damageEventArgs = new DamageEventArgs()
        {
            damageAmount = amount,
            damagedPoint = transform.position + Vector3.up * 0.3f
        };

        OnAnyUnitDamaged?.Invoke(this, damageEventArgs);

        OnHPChanged?.Invoke(this, EventArgs.Empty);

        if (currentHP <= 0.0f)
        {
            Die();
        }
    }

    private void Die()
    {
        OnDie?.Invoke(this, EventArgs.Empty);
        PoolManager.Instance.Despawn(gameObject);
    }

    public void Heal(float amount)
    {
        currentHP += amount;

        OnHPChanged?.Invoke(this, EventArgs.Empty);
    }

    public float GetCurrentHP()
    {
        return currentHP;
    }

    public float GetHPAmount()
    {
        return currentHP / maxHP;
    }
}