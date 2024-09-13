using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoinMagnetic : MonoBehaviour
{
    [SerializeField] private LayerMask coinLayerMask;

    private void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 5.0f, coinLayerMask);

        if (colliders == null)
        {
            return;
        }

        foreach (Collider2D collider in colliders)
        {
            if (collider == null)
            {
                continue;
            }

            collider.transform.position = Vector2.Lerp(collider.transform.position, transform.position, 6.0f * Time.deltaTime);
        }
    }
}