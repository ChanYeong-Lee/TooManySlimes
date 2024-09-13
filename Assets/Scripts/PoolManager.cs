using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance { get; private set; }
    private Dictionary<int, Queue<GameObject>> poolDictionary;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one PoolManager");
            Destroy(gameObject);
            return;
        }

        Instance = this;

        poolDictionary = new Dictionary<int, Queue<GameObject>>();
    }

    public void Prespawn(GameObject prefab, int count, Transform parent = null)
    {
        int prefabKey = Animator.StringToHash(prefab.name);

        if (poolDictionary.ContainsKey(prefabKey) == false)
        {
            poolDictionary[prefabKey] = new Queue<GameObject>();    
        }

        while (poolDictionary[prefabKey].Count < count)
        {
            GameObject prespawnObject = Instantiate(prefab, parent);
            prespawnObject.SetActive(false);

            prespawnObject.name = prefab.name;
            poolDictionary[prefabKey].Enqueue(prespawnObject);
        }
    }

    public GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent = null)
    {
        int prefabKey = Animator.StringToHash(prefab.name);

        GameObject spawnedObject;

        if (poolDictionary.ContainsKey(prefabKey) == false)
        {
            poolDictionary[prefabKey] = new Queue<GameObject>();
            Debug.Log("New Queue Added " + prefab.name);
        }

        Queue<GameObject> poolQueue = poolDictionary[prefabKey];

        if (poolQueue.Count > 0)
        {
            spawnedObject = poolQueue.Dequeue();
            spawnedObject.transform.position = position;
            spawnedObject.transform.rotation = rotation;
            spawnedObject.transform.parent = parent;
            spawnedObject.SetActive(true);
        }
        else
        {
            spawnedObject = Instantiate(prefab, position, rotation, parent);
        }
        
        spawnedObject.name = prefab.name;
        return spawnedObject;
    }

    public void Despawn(GameObject gameObject)
    {
        int prefabKey = Animator.StringToHash(gameObject.name);

        if (poolDictionary.ContainsKey(prefabKey) == false)
        {
            poolDictionary[prefabKey] = new Queue<GameObject>();
        }

        gameObject.SetActive(false);
        gameObject.transform.parent = null;
        poolDictionary[prefabKey].Enqueue(gameObject);
    }
}
