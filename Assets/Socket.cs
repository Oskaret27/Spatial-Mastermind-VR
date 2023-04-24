using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))] 
public class Socket : MonoBehaviour
{
    [SerializeField] Vector3 offset;

    Transform offsetTransform;
    OVRGrabbable grabbable;
    public bool cubeOn => grabbable != null;
    
    private void OnTriggerStay(Collider other)
    {

        bool isGrabbable = other.gameObject.TryGetComponent<OVRGrabbable>(out OVRGrabbable aux);

        if (!isGrabbable) return;

        if (cubeOn && aux != grabbable) return;
        grabbable = aux;

        if (grabbable.isGrabbed) 
        {
            grabbable = null;
            return;
        }
        
        other.gameObject.GetComponent<Rigidbody>().isKinematic = true;

        grabbable.transform.position = offsetTransform.position;
        grabbable.transform.rotation = Quaternion.identity;
    }
    
    private void Start()
    {
        offsetTransform = new GameObject(nameof(offsetTransform)).transform;   
        offsetTransform.SetParent(transform);
        offsetTransform.localPosition = offset;
    }
}
