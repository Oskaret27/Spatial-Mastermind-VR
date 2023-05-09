using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    [SerializeField]UnityEvent<Material> onPressed = new UnityEvent<Material>();

    private void OnCollisionEnter(Collision collision)
    {
        onPressed.Invoke(GetComponent<MeshRenderer>().sharedMaterial);
       
    }

    private void Start()
    {
        var manager = FindObjectOfType<ThrowYourChoiceMinigame>();
        onPressed.AddListener(manager.checkMaterial);
    }
}
