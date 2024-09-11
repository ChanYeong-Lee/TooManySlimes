using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject prefab;
    private Stack<GameObject> spawnedObjectsStack;

    private void Awake()
    {
        spawnedObjectsStack = new Stack<GameObject>();
    }
    private void Start()
    {
        PoolManager.Instance.Prespawn(prefab, 100, transform);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            spawnedObjectsStack.Push(PoolManager.Instance.Spawn(prefab, transform.position, Quaternion.identity));
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (spawnedObjectsStack.Count > 0)
            {
                PoolManager.Instance.Despawn(spawnedObjectsStack.Pop());
            }
        }
    }
}
