using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MeteorPistol : MonoBehaviour
{
    public ParticleSystem particles;

    public LayerMask layerMask;
    public Transform shootSource;
    public float distance;
    void Start()
    {
        XRGrabInteractable interactable = GetComponent<XRGrabInteractable>();
        interactable.activated.AddListener(x => StartShoot());
        interactable.deactivated.AddListener(x => StopShoot());

    }

    public void StartShoot()
    {
        AudioManager.instance.Play("Pistol");
        particles.Play();
    }

    public void StopShoot()
    {
        AudioManager.instance.Stop("Pistol");
        particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
    }

    private void Update()
    {
        if (particles.isPlaying)
        {
            RaycastCheck();
        }
   
    }

    void RaycastCheck()
    {

        RaycastHit hit;
        Ray ray = new Ray(shootSource.position, shootSource.forward);
        bool hasHit = Physics.Raycast(ray, out hit, distance, layerMask);
      
        if (hasHit)
        {
            hit.transform.gameObject.SendMessage("Break", SendMessageOptions.DontRequireReceiver);
        }
    }
}
