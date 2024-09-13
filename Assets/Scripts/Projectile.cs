using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float shotSpeed;
    [SerializeField] private bool isEnemy;
    [SerializeField] private bool canPenetration;

    private Collider2D col;
    
    private void Awake()
    {
        col = GetComponent<Collider2D>();
    }

    private void Update()
    {
        Vector3 moveDir = transform.up * shotSpeed * Time.deltaTime;
        transform.position += moveDir;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isEnemy)
        {
            if (collision.GetComponent<PlayerHeight>() != null)
            {
                collision.GetComponent<HealthSystem>().Damage(damage);
                if (canPenetration == false)
                {
                    PoolManager.Instance.Despawn(gameObject);
                }
            }
        }
        else
        {
            if (collision.GetComponent<EnemyAttack>() != null)
            {
                collision.GetComponent<HealthSystem>().Damage(damage);
                if (canPenetration == false)
                {
                    PoolManager.Instance.Despawn(gameObject);
                }
            }
        }
    }
}
