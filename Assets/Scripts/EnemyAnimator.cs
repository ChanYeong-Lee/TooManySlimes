using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer spriteRenderer;
    protected EnemyAttack enemyAttack;
    protected Color defaultColor;

    protected virtual void Awake()
    {
        enemyAttack = GetComponent<EnemyAttack>();
        defaultColor = spriteRenderer.color;
    }

    protected virtual void Start()
    {
        enemyAttack.OnAttackStart += EnemyAttack_OnAttackStart;
        enemyAttack.OnAttackChargeAmountUpdate += EnemyAttack_OnAttackChargeAmountUpdate;
        enemyAttack.OnAttackComplete += EnemyAttack_OnAttackComplete;
        enemyAttack.OnRecovery += EnemyAttack_OnRecovery;
    }

    protected virtual void EnemyAttack_OnAttackStart(object sender, EventArgs e)
    {

    }

    protected virtual void EnemyAttack_OnAttackChargeAmountUpdate(object sender, float chargeAmount)
    {
        spriteRenderer.color = new Color(1.0f, 0.0f, 0.0f, chargeAmount);
    }

    protected virtual void EnemyAttack_OnAttackComplete(object sender, EventArgs e)
    {
        spriteRenderer.color = defaultColor;
    }

    protected virtual void EnemyAttack_OnRecovery(object sender, EventArgs e)
    {
        spriteRenderer.color = defaultColor;
    }
}
