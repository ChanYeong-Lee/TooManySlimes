using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float maxHP;
    private float currentHP;

    private void OnEnable()
    {
        currentHP = maxHP;
    }

    public void Damage(float amount)
    {
        Debug.Log("Damage " + amount);
        currentHP -= amount;
    }

    public void Heal(float amount)
    {
        Debug.Log("Heal " + amount);
        currentHP += amount;
    }
}
