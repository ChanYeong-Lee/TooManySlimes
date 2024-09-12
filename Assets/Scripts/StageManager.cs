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
    private State state;
    private StageSO currentStageSO;
    private LevelData currentLevelData;
    private int currentStageIndex = 0;
    private int currentLevelDataIndex = 0;

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

    private void Update()
    {
        if (state == State.Pause)
        {
            return;
        }

        if (currentLevelDataIndex < currentStageSO.levelDataList.Count)
        {

        }

        if (currentStageSO.levelDataList[currentLevelDataIndex].startHeight < PlayerHeight.Instance.GetHeight())
        {

        }

        switch (currentLevelData.levelDataSO)
        {
            case MonsterLevelDataSO monsterLevelDataSO:
                break;
        }
    }

    public void PauseGame()
    {
        state = State.Pause;
    }

    public void StartStage()
    {
        state = State.Progressing;
    }
}