using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    private float horizontal;
    private bool isCharging;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one InputManager");
            Destroy(gameObject);
        }
        
        Instance = this;
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        isCharging = Input.GetKey(KeyCode.Escape);
    }

    public float GetHorziontal()
    {
        return horizontal;
    }

    public bool IsCharging()
    {
        return isCharging;
    }


}
