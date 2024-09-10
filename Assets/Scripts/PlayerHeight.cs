using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeight : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private float height;
    [SerializeField] private bool isMoving = true;

    private void Update()
    {
        if (isMoving == false)
        {
            return;
        }

        height += moveSpeed * Time.deltaTime;
    }

    public void SetIsMoving(bool isMoving)
    {
        this.isMoving = isMoving;
    }

    public float GetHeight()
    {
        return height;
    }
}
