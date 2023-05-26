using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class FixOClockMinigame : MonoBehaviour
{

    [SerializeField] public GearMovement gear;
    [SerializeField] Transform shapes;
    [SerializeField] int pointsWin;
    [SerializeField] Text SuccessesText;
    [SerializeField] Text FailuresText;
    [SerializeField] GameObject canvas;

    int success = 0;
    int fails = 0;

    void Update()
    {
        SuccessesText.text = success.ToString();
        FailuresText.text = fails.ToString();
    }

    public void StartMiniGame() 
    {
        success = 0;
        fails = 0;

        FindObjectOfType<AudioManager>().Play("Explication");
        gear.gameObject.SetActive(true);
        shapes.gameObject.SetActive(true);
        
        UpdateShape();
    }

    private void UpdateShape() 
    {
        int rnd = Random.Range(0, shapes.childCount - 1);
        gear.isColliding = false;

        for (int i = 0; i < shapes.childCount; i++)
        {
            shapes.GetChild(i).gameObject.SetActive(i == rnd);
        }
    }

    public void EndMiniGame() 
    {
        gear.gameObject.SetActive(false);
        shapes.gameObject.SetActive(false);

        PlayerPrefs.SetInt("Level1Successes", success);
        PlayerPrefs.SetInt("Level1Failures", fails);
    }

    public void OnButtonPressed() 
    {
        const float SPEED_INCR = 10.0f;

        if (gear.isColliding)
        {
            FindObjectOfType<AudioManager>().Play("SuccessCollision");
            success += 1;
            UpdateShape();
            gear.speed += SPEED_INCR;

            if (pointsWin == success) 
            {          
                EndMiniGame();
                FindObjectOfType<AudioManager>().Play("Congratulations");
                canvas.gameObject.SetActive(true);
            }          
        }

        else 
        {
            FindObjectOfType<AudioManager>().Play("FailCollision");
            fails += 1;
        }
    }
}
