using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float moveSpeed = 5.0f;
    private float boundaryLimit = 4.0f;

    private void Update()
    {
        Vector3 nextPos = transform.position + InputManager.Instance.GetHorziontal() * Vector3.right * moveSpeed * Time.deltaTime;
        if (nextPos.x < boundaryLimit && nextPos.x > -boundaryLimit)
        {
            transform.position = nextPos;
        }
    }

}
