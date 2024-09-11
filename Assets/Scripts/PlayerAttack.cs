using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private LayerMask attackLayerMask;

    [SerializeField] private SpriteRenderer spriteRenderer;

    private bool canMultiple;
    private float attackDamage = 10.0f;
    [SerializeField] private float attackSpeed = 1.0f;
    private float attackArea = 1.0f;

    private float stateTimer = 0.0f;
    private bool isAttacking;

    private enum State
    {
        Charge,
        AfterAttack,
        Recovery,
    }

    private State state;

    private void Update()
    {
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
            float recoveryAmount = 1.0f * Time.deltaTime;
            spriteRenderer.transform.localPosition = Vector2.Lerp(spriteRenderer.transform.localPosition, Vector2.zero, recoveryAmount);
            isAttacking = false;
            return;
        }

        if (isAttacking == false)
        {
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

                float chargeLerpAmount = (chargeTime - stateTimer) / chargeTime;
                Vector2 chargeTargetPos = Vector2.Lerp(Vector2.zero, Vector2.up * (-0.5f), chargeLerpAmount);

                spriteRenderer.transform.localPosition = Vector2.Lerp(spriteRenderer.transform.localPosition, chargeTargetPos, followLerpAmount);
                break;
            case State.AfterAttack:

                float attackTime = attackSpeed * 0.1f;

                float attackLerpAmount = (attackTime - stateTimer) / attackTime;
                Vector2 attackTargetPos = Vector2.Lerp(Vector2.up * (-0.5f), Vector2.up * (0.2f), attackLerpAmount);

                spriteRenderer.transform.localPosition = Vector2.Lerp(spriteRenderer.transform.localPosition, attackTargetPos, followLerpAmount);
                break;
            case State.Recovery:
                float recoveryTime = attackSpeed * 0.1f;

                float recoveryLerpAmount = (recoveryTime - stateTimer) / recoveryTime;
                Vector2 recoveryTargetPos = Vector2.Lerp(Vector2.up * (0.2f), Vector2.zero, recoveryLerpAmount);

                spriteRenderer.transform.localPosition = Vector2.Lerp(spriteRenderer.transform.localPosition, recoveryTargetPos, followLerpAmount);
                break;
        }
    }

    public void NextState()
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
                break;
            case State.Recovery:
                spriteRenderer.transform.localPosition = Vector2.zero;
                isAttacking = false;
                break;
        }
    }

    private bool CheckTarget()
    {
        return Physics2D.OverlapBox((Vector2)transform.position + Vector2.up * 0.65f, new Vector2(attackArea, 0.2f), 0.0f, attackLayerMask);
    }

    private void ApplyDamage()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll((Vector2)transform.position + Vector2.up * 0.65f, new Vector2(attackArea, 0.2f), 0.0f, attackLayerMask);

        if (canMultiple)
        {
            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject.TryGetComponent(out HealthSystem healthSystem))
                {
                    healthSystem.Damage(attackDamage);
                }
            }
        }
        else
        {
            HealthSystem minimumDistanceHealthSystem = null;
            float minimumDistance = Mathf.Infinity;
            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject.TryGetComponent(out HealthSystem healthSystem))
                {
                    float distance = Vector2.Distance(transform.position, collider.transform.position);
                    if (distance < minimumDistance)
                    {
                        minimumDistanceHealthSystem = healthSystem;
                        minimumDistance = distance;
                    }
                }
            }
            if (minimumDistanceHealthSystem != null)
            {
                minimumDistanceHealthSystem.Damage(attackDamage);
            }
        }

    }

    public void Attack()
    {
        isAttacking = true;
        stateTimer = attackSpeed * 0.8f;
        state = State.Charge;
    }
}
