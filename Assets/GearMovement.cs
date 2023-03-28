using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearMovement : MonoBehaviour
{
    [SerializeField]
    public float speed;
    public GameObject gearShape;
    public bool isColliding;

    void Start()
    {
        
    }

    void Update()
    {
        float time = Time.deltaTime * speed;
        Quaternion quaternionRotation = Quaternion.AngleAxis(time, Vector3.forward);
        transform.rotation *= quaternionRotation; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.CompareTag("GearShapes"))
        {
            isColliding = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.parent.CompareTag("GearShapes"))
        {
            isColliding = false;
        }
    }

}
