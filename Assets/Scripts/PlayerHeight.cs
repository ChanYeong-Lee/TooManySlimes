using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHeight : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private float height;
    [SerializeField] private bool isMoving = true;
    [SerializeField] private LayerMask collisionLayerMask;

    private BoxCollider2D boxCollider2D;
    private float startPosY = -4.0f;

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        float lerpValue = 2.0f * Time.deltaTime;
        transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, startPosY), lerpValue);

        CheckCollision();

        if (isMoving == false)
        {
            return;
        }

        height += moveSpeed * Time.deltaTime;
        
    }

    private void CheckCollision()
    {
        Collider2D hitCollider = Physics2D.OverlapBox((Vector2)transform.position + Vector2.up * 0.65f, new Vector2(1.0f, 0.2f), 0.0f, collisionLayerMask);

        if (hitCollider != null)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
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
