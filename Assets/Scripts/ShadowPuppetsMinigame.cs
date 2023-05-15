using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ShadowPuppetsMinigame : MonoBehaviour
{

    [SerializeField] int pointsWin;
    [SerializeField] Text SuccessesText;
    [SerializeField] Text FailuresText;
    [SerializeField] GameObject canvas;
    [SerializeField] ShadowPuppetsLevel[] levels;
    [SerializeField] Transform modelParent;
    [SerializeField] ButtonVR[] buttons;
    [SerializeField] GlobalScoreObject globalScore;

    public int success = 0;
    public int fails = 0;
    int level = 0;
    int correctIndex;
    bool endGame = false;

    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("Explication");
        PrepareLevel();
    }
    void Update()
    {     
        SuccessesText.text = success.ToString();
        FailuresText.text = fails.ToString();     
    }

    void PrepareLevel() 
    {
        ShadowPuppetsLevel levelData = levels[level];

        if (modelParent.childCount > 0) 
            Destroy(modelParent.GetChild(0).gameObject);

        Instantiate(levelData.model, modelParent);

        correctIndex = Random.Range(0, buttons.Length-1);

        for (int i=0, j=0; i<buttons.Length; i++) {

            if (i == correctIndex)
            {   
                buttons[i].transform.GetChild(0).GetComponent<MeshRenderer>().material = levelData.correctMaterial;
            }
            else 
            {
                buttons[i].transform.GetChild(0).GetComponent<MeshRenderer>().material = levelData.otherMaterials[j];
                j++;
            }                     
        }
    }


    public void EndMiniGame()
    {
        endGame = true;
        Destroy(modelParent.GetChild(0).gameObject);
        FindObjectOfType<AudioManager>().Play("Congratulations");
        canvas.gameObject.SetActive(true);

        globalScore.levelScores[1] = new LevelScore(success, fails);
    }

    public void OnButtonPressed(int index)
    {
        if (!endGame) 
        {
            if (index == correctIndex)
            {
                FindObjectOfType<AudioManager>().Play("SuccessCollision");
                level += 1;
                success += 1;

                if (pointsWin == success)
                {
                    EndMiniGame();
                }

                PrepareLevel();
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("FailCollision");
                fails += 1;

            }
        }
        
    }
}