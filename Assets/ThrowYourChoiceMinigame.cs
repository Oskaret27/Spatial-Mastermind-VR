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
    [SerializeField] ThrowYourChoiceLevel[] levels;
    [SerializeField] Transform modelParent;
    [SerializeField] GameObject[] options;

    public int success = 0;
    public int fails = 0;
    int level = 0;
    int correctIndex;
    private Vector3 ballOriginalPosition;
    bool endGame = false;

    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("Explication4");
        ballOriginalPosition = ball.transform.position;
        PrepareLevel();
    }
    void Update()
    {
        SuccessesText.text = success.ToString();
        FailuresText.text = fails.ToString();
    }

    void PrepareLevel()
    {
        ThrowYourChoiceLevel levelData = levels[level];

        if (modelParent.childCount > 0)
            Destroy(modelParent.GetChild(0).gameObject);

        Instantiate(levelData.model, modelParent);

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

    /*
      
     //CHECK WIN = comprobar collisión 3 seg dentro de la caja correcta, sino que se reinicie la bola

    public void checkWin()
    {
        ball.transform.position = ballOriginalPosition;
        ball.transform.rotation = Quaternion.Euler(90f, 0f, 90f);

        if (endGame) return;

        bool success = lvlSuccess() && !timer.IsTimeOver();

        if (success)
        {
            FindObjectOfType<AudioManager>().Play("SuccessCollision");
            this.success++;
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("FailCollision");
            this.fails++;
        }

        level++;

        if (level >= levels.Length)
        {
            EndMiniGame();
        }
        else
        {
            PrepareLevel();
        }
    }
    

    
    public void EndMiniGame()
    {
        endGame = true;
        Destroy(modelParent.GetChild(0).gameObject);
        FindObjectOfType<AudioManager>().Play("Congratulations");
        canvas.gameObject.SetActive(true);
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
    */
}