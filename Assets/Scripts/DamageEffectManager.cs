using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffectManager : MonoBehaviour
{
    [SerializeField] private GameObject damageUIPrefab;

    private void Start()
    {
        HealthSystem.OnAnyUnitDamaged += HealthSystem_OnAnyUnitDamaged;
    }

    private void HealthSystem_OnAnyUnitDamaged(object sender, HealthSystem.DamageEventArgs e)
    {
        GameObject damageUI = PoolManager.Instance.Spawn(damageUIPrefab, e.damagedPoint, Quaternion.identity);
        damageUI.GetComponent<DamageUI>().Setup(e.damageAmount);
    }
}

