using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHeight : MonoBehaviour
{
    public static PlayerHeight Instance { get; private set; }

    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private LayerMask collisionLayerMask;

    private bool isMoving = true;
    private bool isCollision = true;
    private float height;
    private float startPosY = -4.0f;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one PlayerHeight");
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Update()
    {
        if (isMoving == false)
        {
            return;
        }

        float lerpValue = 2.0f * Time.deltaTime;
        transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, startPosY), lerpValue);

        CheckCollision();

        if (isCollision == false)
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
            isCollision = false;
        }
        else
        {
            isCollision = true;
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

    public void ResetHeight()
    {
        height = 0.0f;
    }
}
