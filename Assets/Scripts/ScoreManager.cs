using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text succeses;
    public Text failures;

    public void getLevelScore(int index) 
    {
        succeses.text = PlayerPrefs.GetInt("Level" + index.ToString() + "Successes").ToString();
        failures.text = PlayerPrefs.GetInt("Level" + index.ToString() + "Failures").ToString();
    }
}
