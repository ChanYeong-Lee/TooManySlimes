using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public static ObjectSpawner Instance { get; private set; }

    [SerializeField] private List<Transform> objectPointsList;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one ObjectSpawner");
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }


    public void SpawnObject(GameObject gameObject, int spawnPoint, Quaternion rotation)
    {
        if (spawnPoint > objectPointsList.Count)
        {
            return;
        }

        PoolManager.Instance.Spawn(gameObject, objectPointsList[spawnPoint].position, rotation);
    }

}
