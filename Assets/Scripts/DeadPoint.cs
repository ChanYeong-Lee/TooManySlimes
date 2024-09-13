using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPoint : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<FallingObject>())
        {
            PoolManager.Instance.Despawn(collision.gameObject);
        }
    }

}
