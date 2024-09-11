using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stage  -  MonsterLevelDataSO", menuName = "LevelDataSO/New Monster Level Data")]
public class MonsterLevelDataSO : LevelDataSO
{
    public List<MonsterPrefabData> monsterPrefabDataList;
}

[Serializable]
public class MonsterPrefabData
{
    public GameObject monsterPrefab;
    [Range(0.0f, 1.0f)] public float percent;
}
