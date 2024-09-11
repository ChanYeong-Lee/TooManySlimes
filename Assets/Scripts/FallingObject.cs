using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    private PlayerHeight playerHeight;
    private float spawnedHeight = 0.0f;

    private void Awake()
    {
        playerHeight = FindAnyObjectByType<PlayerHeight>();
    }

    private void OnEnable()
    {
        spawnedHeight = transform.position.y - playerHeight.GetHeight();
    }

    private void Update()
    {
        if (playerHeight == null)
        {
            return;
        }

        transform.position = new Vector2(transform.position.x, spawnedHeight - playerHeight.GetHeight());
    }
}
