using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    protected enum State
    {
        Charge,
        AfterAttack,
        Recovery,
    }

    public event EventHandler<float> OnAttackChargeAmountUpdate;
    public event EventHandler OnAttackStart;
    public event EventHandler OnAttackComplete;
    public event EventHandler OnRecovery;

    protected BoxCollider2D boxCollider2D;
    [SerializeField] private bool canAttack = true;
    [SerializeField] protected SpriteRenderer spriteRenderer;
    [SerializeField] protected LayerMask attackLayerMask;
    [SerializeField] protected float attackDamage = 5.0f;
    [SerializeField] protected float attackSpeed = 1.0f;
    [SerializeField] protected Vector2 attackArea = new Vector2(1.0f, 0.3f);

    protected Vector2 attackAreaCenter;

    protected float stateTimer = 0.0f;
    protected bool isAttacking;
    protected State state;

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();

        attackAreaCenter = new Vector2(0.0f, -boxCollider2D.size.y * 0.5f - attackArea.y * 0.5f);
    }

    private void Update()
    {
        if (canAttack == false)
        {
            return;
        }

        if (CheckTarget())
        {
            if (isAttacking == false)
            {
                Attack();
                return;
            }
        }
        else
        {
            isAttacking = false;
        }

        if (isAttacking == false)
        {
            OnRecovery?.Invoke(this, EventArgs.Empty);
            return;
        }

        stateTimer -= Time.deltaTime;

        if (stateTimer < 0.0f)
        {
            NextState();
        }

        float followLerpAmount = 5.0f * Time.deltaTime;

        switch (state)
        {
            case State.Charge:
                float chargeTime = attackSpeed * 0.8f;

                float chargeAmount = 1.0f - stateTimer / chargeTime;
                OnAttackChargeAmountUpdate?.Invoke(this, chargeAmount);
                break;
            case State.AfterAttack:
                break;
            case State.Recovery:
                break;
        }
    }

    protected virtual void NextState()
    {
        switch (state)
        {
            case State.Charge:
                float attackTime = attackSpeed * 0.1f;
                stateTimer = attackTime;
                state = State.AfterAttack;
                break;
            case State.AfterAttack:
                float recoveryTime = attackSpeed * 0.1f;
                stateTimer = recoveryTime;
                state = State.Recovery;

                ApplyDamage();
                OnAttackComplete?.Invoke(this, EventArgs.Empty);
                break;
            case State.Recovery:
                isAttacking = false;
                break;
        }
    }

    private bool CheckTarget()
    {
        Vector2 checkPos = (Vector2)transform.position - new Vector2(0.0f, boxCollider2D.size.y * 0.5f + 0.15f);
        Vector2 checkArea = new Vector2(boxCollider2D.size.x, 0.2f);

        return Physics2D.OverlapBox(checkPos, checkArea, 0.0f, attackLayerMask);
    }

    private void ApplyDamage()
    {
        Vector2 checkPos = (Vector2)transform.position + attackAreaCenter;
        Collider2D collider = Physics2D.OverlapBox(checkPos, attackArea, 0.0f, attackLayerMask);
        if (collider != null && collider.gameObject.TryGetComponent(out HealthSystem healthSystem))
        {
            healthSystem.Damage(attackDamage);
        }
    }

    protected virtual void Attack()
    {
        isAttacking = true;
        stateTimer = attackSpeed * 0.8f;
        state = State.Charge;

        OnAttackStart?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetAttackArea()
    {
        return attackArea;
    }

    public Vector2 GetAttackAreaCenter()
    {
        return attackAreaCenter;
    }
}
