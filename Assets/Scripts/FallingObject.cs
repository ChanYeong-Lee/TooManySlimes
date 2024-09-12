using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    private float spawnedHeight = 0.0f;

    private void OnEnable()
    {
        spawnedHeight = transform.position.y + PlayerHeight.Instance.GetHeight();
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, (spawnedHeight - PlayerHeight.Instance.GetHeight()), 0.0f);
    }
}
