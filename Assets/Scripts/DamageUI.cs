using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageUI : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private TextMeshPro damageText;

    private WaitForSeconds despawnDelay = new WaitForSeconds(0.5f);

    private void OnEnable()
    {
        rb.velocity = new Vector2(Random.Range(-0.5f, 0.5f), 3.0f);
        StartCoroutine(DespawnCoroutine());
    }

    public void Setup(float damageAmount)
    {
        damageText.text = $"{damageAmount:F0}";
    }

    private IEnumerator DespawnCoroutine()
    {
        yield return despawnDelay;
        PoolManager.Instance.Despawn(gameObject);
    }
}
