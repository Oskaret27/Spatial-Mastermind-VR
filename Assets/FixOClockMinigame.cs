using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixOClockMinigame : MonoBehaviour, IMinigame
{

    private GameObject gearObject;

    void Start()
    {
        gearObject = new GameObject("GearObject");
        GearMovement gearMovement = gearObject.AddComponent<GearMovement>();

        //gearMovement.speed = 10.0f;

        gearObject.SetActive(false);
    }


    void Update()
    {
        
    }

    public void StartMiniGame() 
    {
        gearObject.SetActive(true);
    }

    public void EndMiniGame() 
    {
        gearObject.SetActive(false);
    }
}

public interface IMinigame 
{ 

}
