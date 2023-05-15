using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GlobalScoreObject", menuName = "ScriptableObjects/GlobalScoreObject", order = 1)]

public class GlobalScoreObject : ScriptableObject
{
    public LevelScore[] levelScores;

    [ContextMenu("Reset")]
    public void Reset() 
    {
        levelScores = new LevelScore[4];
    }
}

[System.Serializable]
public class LevelScore 
{
    public int succeses;
    public int failures;

    public LevelScore(int succeses, int failures) 
    {
        this.succeses = succeses;
        this.failures = failures;
    }
}
