using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerZone : MonoBehaviour
{
    [SerializeField] private string targetTag;
    public UnityEvent<GameObject> onEnterEvent;

    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log("OnTriggerEvent Occured");
        if(other.gameObject.tag == targetTag)
        {
            Debug.Log("Tag " + other.gameObject.tag + " matched");
            onEnterEvent.Invoke(other.gameObject);
        }
    } 
}
