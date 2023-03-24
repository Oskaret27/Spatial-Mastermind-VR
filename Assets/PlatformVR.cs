using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformVR : MonoBehaviour
{
    AudioSource sound;

    private bool playerOnPlatform = false;

    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sound.Play();
            playerOnPlatform = true;
            //StartMinigame();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sound.Stop();
            playerOnPlatform = false;
            //StopMinigame();
        }
    }

}