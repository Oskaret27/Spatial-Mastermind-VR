using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ThrowYourChoiceMinigame : MonoBehaviour
{

    [SerializeField] int pointsWin;
    [SerializeField] Text SuccessesText;
    [SerializeField] Text FailuresText;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject ball;
    [SerializeField] Timer timer;
    [SerializeField] ThrowYourChoiceLevel[] levels;
    [SerializeField] Transform modelParent;
    [SerializeField] GameObject[] options;


    public int success = 0;
    public int fails = 0;
    int level = 0;
    int correctIndex;
    Vector3 ballOriginalPosition;
    bool endGame = false;
    bool closedDoors = false;
    GameObject model;

    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("Explication");
        ballOriginalPosition = ball.transform.position;
        PrepareLevel();
    }
    void Update()
    {
        SuccessesText.text = success.ToString();
        FailuresText.text = fails.ToString();
        closeDoor();
    }

    //objeto manipulable 30 seg, luego se destruye, se cierran las puertas y PrepareLevel()
    void closeDoor() 
    {
        if (timer.IsTimeOver() && timer.initialized && !closedDoors)
        {
            Destroy(model);
            model = null;
            GameObject.Find("Doors").GetComponent<Animator>().SetTrigger("CloseTest");
            closedDoors = true;
            timer.gameObject.SetActive(false);

            PrepareLevel();
        }
    }

    public void PrepareLevel()
    {
        ThrowYourChoiceLevel levelData = levels[level];

        model = Instantiate(levelData.model, modelParent);

        correctIndex = Random.Range(0, options.Length - 1);

        for (int i = 0, j = 0; i < options.Length; i++)
        {

            if (i == correctIndex)
            {
                options[i].transform.GetComponent<MeshRenderer>().material = levelData.correctMaterial;
            }
            else
            {
                options[i].transform.GetComponent<MeshRenderer>().material = levelData.otherMaterials[j];
                j++;
            }
        }
    }

    public void checkMaterial(Material material) 
    {

        if (!endGame)
        {
            if (material == levels[level].correctMaterial)
            {              
                FindObjectOfType<AudioManager>().Play("SuccessCollision");
                level += 1;
                success += 1;
                ball.transform.position = ballOriginalPosition;

                GameObject.Find("Doors").GetComponent<Animator>().SetTrigger("OpenTest");
                timer.gameObject.SetActive(true);                                

                if (pointsWin == success)
                {
                    EndMiniGame();
                }
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("FailCollision");
                fails += 1;
                ball.transform.position = ballOriginalPosition;
                
            }
        }
    }

    public void EndMiniGame()
    {
        endGame = true;
        Destroy(modelParent.GetChild(0).gameObject);
        FindObjectOfType<AudioManager>().Play("Congratulations");
        canvas.gameObject.SetActive(true);
    }
 
}