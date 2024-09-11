using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance { get; private set; }

    [SerializeField] private List<StageSO> stageSOList;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one StageManager");
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
}