using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixOClockMinigame : MonoBehaviour, IMinigame
{
    [SerializeField]
    
    public GearMovement gear;

    void Start()
    {
        //gearMovement.speed = 10.0f;

        gear.gameObject.SetActive(false);
    }


    void Update()
    {
        
    }

    public void StartMiniGame() 
    {
        gear.gameObject.SetActive(true);
    }

    public void EndMiniGame() 
    {
        gear.gameObject.SetActive(false);
    }
}

public interface IMinigame 
{ 

}
