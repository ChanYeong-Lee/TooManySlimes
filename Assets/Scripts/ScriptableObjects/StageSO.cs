using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stage  SO", menuName = "New Stage")]
public class StageSO : ScriptableObject
{
    public int stageLevel;
    public List<LevelData> levelDataList;
    public float goalHeight;
}
