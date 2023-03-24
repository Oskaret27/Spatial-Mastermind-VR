using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearMovement : MonoBehaviour
{
    [SerializeField]
    float speed;

    void Start()
    {
        
    }

    void Update()
    {
        float time = Time.deltaTime * speed;
        Quaternion quaternionRotation = Quaternion.AngleAxis(time, Vector3.forward);
        transform.rotation *= quaternionRotation; 
    }
}
