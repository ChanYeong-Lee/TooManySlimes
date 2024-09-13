using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyAttack : EnemyAttack
{
    [SerializeField] private Vector2 attackSpeedRange;

    protected override void Attack()
    {
        attackSpeed = Random.Range(attackSpeedRange.x, attackSpeedRange.y);
        int randomValue = Random.Range(0, 2);
        switch (randomValue)
        {
            case 0:
                attackAreaCenter = new Vector2(boxCollider2D.size.x - attackArea.x, - attackArea.y);
                break;
            case 1:
                attackAreaCenter = new Vector2(-(boxCollider2D.size.x - attackArea.x), - attackArea.y);
                break;
        }
        base.Attack();
    }


}
