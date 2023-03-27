using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlatformVR : MonoBehaviour
{
    AudioSource sound;

    private bool playerOnPlatform = false;
    public UnityEvent onPlayerInPlatform = new UnityEvent();
    public UnityEvent onPlayerOutPlatform = new UnityEvent();
    private FixOClockMinigame minigame;

    void Start()
    {
        sound = GetComponent<AudioSource>();
        minigame = gameObject.AddComponent<FixOClockMinigame>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sound.Play();
            playerOnPlatform = true;
            onPlayerInPlatform.Invoke();
            minigame.StartMiniGame();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sound.Stop();
            playerOnPlatform = false;
            onPlayerOutPlatform.Invoke();
            minigame.EndMiniGame();
        }
    }

}