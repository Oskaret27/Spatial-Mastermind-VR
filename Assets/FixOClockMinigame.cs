using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixOClockMinigame : MonoBehaviour, IMinigame
{

    void Start()
    {
        //PlatformVR platform = FindObjectOfType<PlatformVR>();
        //platform.onPlayerInPlatform.AddListener(StartMiniGame);
        //platform.onPlayerOutPlatform.AddListener(EndMiniGame);
    }


    void Update()
    {
        
    }

    public void StartMiniGame() { print("uepuep"); }

    public void EndMiniGame() { print("rip"); }
}

public interface IMinigame 
{ 

}
