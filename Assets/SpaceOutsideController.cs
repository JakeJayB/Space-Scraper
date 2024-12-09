using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class SpaceOutsideController : MonoBehaviour
{
    [SerializeField] private XRLever lever;
    [SerializeField] private XRKnob knob;

    [SerializeField] private float forwardSpeed;
    [SerializeField] private float sideSpeed;

    private bool wasOn;

    // Update is called once per frame
    void Update()
    {
        float forwardVel = forwardSpeed * (lever.value ? 1 : 0);
        float sideVel = sideSpeed * (lever.value ? 1 : 0) * Mathf.Lerp(-1, 1, knob.value);

        Vector3 vel = new Vector3(sideVel, 0, forwardVel);
        this.transform.position += vel * Time.deltaTime;

        if (lever.value != wasOn)
        { 
            if (lever.value)
            {
                AudioManager.instance.Play("Engine");
            }
            else
            {
                AudioManager.instance.Stop("Engine");
            }
        }
        wasOn = lever.value;
    }
}
