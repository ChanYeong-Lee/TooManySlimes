using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : MonoBehaviour
{
    private enum State
    {
        Charging,
        Recovery,
    }

    [SerializeField] private bool canAttack;
    [SerializeField] private Transform shotPoint;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float attackSpeed;

    private float stateTimer = 0.0f;
    private State state;

    private void Update()
    {
        if (canAttack == false)
        {
            return;
        }

        stateTimer -= Time.deltaTime;

        if (stateTimer <= 0.0f)
        {
            NextState();
        }

        switch (state)
        {
            case State.Charging:
                break;
            case State.Recovery:
                break;
        }
    }

    public void NextState()
    {
        switch (state)
        {
            case State.Charging:
                stateTimer = attackSpeed * 0.1f;
                state = State.Recovery;
                break;
            case State.Recovery:
                Attack();
                break;
        }
    }

    public void Attack()
    {
        ShotProjectile();

        state = State.Charging;
        stateTimer = attackSpeed * 0.9f;
    }

    private void ShotProjectile()
    {
        PoolManager.Instance.Spawn(projectilePrefab, shotPoint.position, shotPoint.rotation);
    }

    public void SetCanAttack(bool canAttack)
    {
        this.canAttack = canAttack;
    }
}
