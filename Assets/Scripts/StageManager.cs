using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public enum State
    {
        Pause,
        Progressing,
        Transition,
    }

    public static StageManager Instance { get; private set; }

    [SerializeField] private List<StageSO> stageSOList;
    [SerializeField] private TwoWaySelectionTrigger twoWaySelectionTrigger;
    [SerializeField] private GameObject shopTrigger;

    private State state;
    private StageSO currentStageSO;
    private LevelData currentLevelData;
    private int currentStageIndex = 0;
    private int currentLevelDataIndex = 0;
    private bool isActive = false;
    private float prevSpawnHeight;

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
    
    private void Start()
    {
        currentStageSO = stageSOList[0];
        //currentLevelData = currentStageSO.levelDataList[0];
    }

    private void Update()
    {
        if (state == State.Pause)
        {
            return;
        }

        if (currentLevelDataIndex >= currentStageSO.levelDataList.Count)
        {
            return;
        }

        if (currentStageSO.levelDataList[currentLevelDataIndex].startHeight < PlayerHeight.Instance.GetHeight())
        {
            currentLevelData = currentStageSO.levelDataList[currentLevelDataIndex];
            currentLevelDataIndex++;
            isActive = false;
        }
       
        if (currentLevelData == null)
        {
            return;
        }

        switch (currentLevelData.levelDataSO)
        {
            case MonsterLevelDataSO monsterLevelDataSO:
                if (prevSpawnHeight + 2.0f < PlayerHeight.Instance.GetHeight())
                {
                    prevSpawnHeight = PlayerHeight.Instance.GetHeight();
                    for (int i = 0; i < 5; i++)
                    {
                        float randomValue = Random.Range(0.0f, 1.0f);
                        if (randomValue > 0.6f)
                        {
                            float randomSpawnValue = Random.Range(0.0f, 1.0f);
                            float lastSpawnValue = 0.0f;
                            foreach (MonsterPrefabData data in monsterLevelDataSO.monsterPrefabDataList)
                            {
                                if (data.percent < randomSpawnValue)
                                {
                                    ObjectSpawner.Instance.SpawnObject(data.monsterPrefab, i, Quaternion.identity);
                                    break;
                                }
                                else
                                {
                                    lastSpawnValue += data.percent;
                                }
                            }
                        }
                    }
                }
                break;
            case SelectionLevelDataSO selectionLevelDataSO:
                if (isActive)
                {
                    return;
                }
                GameObject spawnObject = ObjectSpawner.Instance.SpawnObject(twoWaySelectionTrigger.gameObject, 2, Quaternion.identity);
                spawnObject.GetComponent<TwoWaySelectionTrigger>().Setup(selectionLevelDataSO.rairity);
                isActive = true;

                break;
            case ShopLevelDataSO shopLevelDataSO:
                break;
            case BossLevelDataSO bossLevelDataSO:
                if (isActive)
                {
                    return;
                }
                ObjectSpawner.Instance.SpawnObject(bossLevelDataSO.bossPrefab.gameObject, 2, Quaternion.identity);
                isActive = true;
                break;
        }
    }

    public void PauseGame()
    {
        state = State.Pause;
        PlayerHeight.Instance.SetIsMoving(false);
    }

    public void StartStage()
    {
        state = State.Progressing;
        PlayerHeight.Instance.SetIsMoving(true);
    }
}