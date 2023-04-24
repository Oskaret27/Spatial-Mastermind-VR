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
    bool endGame = false;
    private Vector3 instructionOriginalPosition;

    private void Start()
    {
        timer.gameObject.SetActive(true);
        instruction.gameObject.SetActive(true);
        instructionOriginalPosition = instruction.transform.position;
        FindObjectOfType<AudioManager>().Play("Explication3");
        PrepareLevel();

    }
    void Update()
    {
        SuccessesText.text = success.ToString();
        FailuresText.text = fails.ToString();
    }

    void PrepareLevel()
    {
        DragTheCubesLevel levelData = levels[level];

        if (modelParentInitial.childCount > 0)
               Destroy(modelParentInitial.GetChild(0).gameObject);

        Instantiate(levelData.model, Vector3.zero, Quaternion.identity, modelParentInitial);


        if (modelParent.childCount > 0) {
            foreach (Transform child in modelParent) 
            {
                GameObject.Destroy(child.gameObject);
            }       
        }


        foreach (GameObject cube in levelData.cubes) 
        {
            Vector3 cubePosition = modelParent.position;

            if (modelParent.childCount > 0)
            {
                // Get the position of the last instantiated cube
                Transform lastCube = modelParent.GetChild(modelParent.childCount - 1);

                cubePosition = lastCube.position + new Vector3(0, cube.GetComponent<Renderer>().bounds.size.y, 0);
            }
            Instantiate(cube, cubePosition, Quaternion.identity, modelParent);
        }               

        instruction.transform.GetChild(0).GetComponent<MeshRenderer>().material = levelData.instructions;
    }


    public void OnButtonPressed()
    {
        instruction.transform.position = instructionOriginalPosition;
        instruction.transform.rotation = Quaternion.Euler(90f, 0f, 90f);
        checkWin();      
    }

    public void EndMiniGame()
    {
        endGame = true;
        FindObjectOfType<AudioManager>().Play("Congratulations");
        canvas.gameObject.SetActive(true);
    }

    public bool lvlSuccess() 
    {
        DragTheCubesLevel levelData = levels[level];
        foreach (int cell in levelData.correctCells)
        {
            if (!matrixSocket[cell].cubeOn) return false;
        }

        return true;
    }

    public void checkWin() 
    {    
        if (!endGame)
        {
            if (lvlSuccess())
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
