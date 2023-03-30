using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlatformVR : MonoBehaviour
{

    private bool playerOnPlatform = false;
    public UnityEvent onPlayerInPlatform = new UnityEvent();
    public UnityEvent onPlayerOutPlatform = new UnityEvent();
 

    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnPlatform = true;
            onPlayerInPlatform.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnPlatform = false;
            onPlayerOutPlatform.Invoke();
        }
    }

}