using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class DragTheCubesMinigame : MonoBehaviour
{
    [SerializeField] int pointsWin;
    [SerializeField] Text SuccessesText;
    [SerializeField] Text FailuresText;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject timer;
    [SerializeField] GameObject instruction;
    [SerializeField] DragTheCubesLevel[] levels;
    [SerializeField] Transform modelParent;
    [SerializeField] Transform modelParentInitial;
    [SerializeField] Socket[] matrixSocket;

    public int success = 0;
    public int fails = 0;
    int level = 0;
    int correctIndex;
    bool endGame = false;

    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("Explication3");
        
    }
    void Update()
    {
        if(ckeckWin()) print("win");
        SuccessesText.text = success.ToString();
        FailuresText.text = fails.ToString();
    }

    void PrepareLevel()
    {
        
        DragTheCubesLevel levelData = levels[level];

        if (modelParentInitial.childCount > 0)
            Destroy(modelParentInitial.GetChild(0).gameObject);

        Instantiate(levelData.model, Vector3.zero, Quaternion.identity, modelParentInitial);

        foreach (GameObject cube in levelData.cubes)
            Instantiate(cube, modelParent);

        instruction.transform.GetChild(0).GetComponent<MeshRenderer>().material = levelData.instructions;
    }

    public void EndMiniGame()
    {
        endGame = true;
        FindObjectOfType<AudioManager>().Play("Congratulations");
        canvas.gameObject.SetActive(true);
    }

    public void OnButtonPressed()
    {
        timer.gameObject.SetActive(true);
        instruction.gameObject.SetActive(true);
        PrepareLevel();
        level++;

        /*
        if (!endGame)
        {
            if (ckeckWin())
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
        */
    }

    public bool ckeckWin() 
    {
        DragTheCubesLevel levelData = levels[level];
        foreach (int cell in levelData.correctCells) 
        {
            if (!matrixSocket[cell].cubeOn) return false;
        }
        return true;
    }
}
