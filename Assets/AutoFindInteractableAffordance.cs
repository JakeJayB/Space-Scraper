using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.State;

public class AutoFindInteractableAffordance : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<XRInteractableAffordanceStateProvider>().interactableSource = this.GetComponentInParent<XRBaseInteractable>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
