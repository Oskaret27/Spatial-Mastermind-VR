using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FixOClockMinigame : MonoBehaviour, IMinigame
{

    [SerializeField] public GearMovement gear;
    [SerializeField] Transform shapes;
    [SerializeField] int pointsWin;

    int success = 0;
    int fails = 0;

    void Start()
    {
        gear.gameObject.SetActive(false);
    }


    void Update()
    {
        
    }

    public void StartMiniGame() 
    {
        gear.gameObject.SetActive(true);
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
        Debug.Log(fails);
        Debug.Log(success);
        gear.gameObject.SetActive(false);
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

            if (pointsWin == success) EndMiniGame();
        }

        else 
        {
            FindObjectOfType<AudioManager>().Play("FailCollision");
            fails += 1;
        }
    }
}

public interface IMinigame 
{ 

}
