using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{

    [SerializeField] private Animator myDoor = null;

    [SerializeField] private bool openTrigger = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            
            if (openTrigger) 
            {

                myDoor.Play("DoorOpen", 0, 0.0f);
                FindObjectOfType<AudioManager>().Play("DoorOpen");
                gameObject.SetActive(false);
            }
        }
    }
}
