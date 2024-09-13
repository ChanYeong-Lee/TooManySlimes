using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerInventory>())
        {
            PlayerInventory.Instance.GainCoin(1);
            PoolManager.Instance.Despawn(gameObject);
        } 
    }
}