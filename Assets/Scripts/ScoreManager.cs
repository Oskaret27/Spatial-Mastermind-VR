using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text succeses;
    public Text failures;
    public GlobalScoreObject globalScore;

    public void getLevelScore(int index) 
    {
        succeses.text = globalScore.levelScores[index].succeses.ToString();
        failures.text = globalScore.levelScores[index].failures.ToString();
    }
}
