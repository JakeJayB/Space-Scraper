using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Breakable : MonoBehaviour
{
    [SerializeField] private List<GameObject> Breakables = new List<GameObject>();
    private float timeToBreak = 1;
    private float timer = 0;
    [SerializeField] private UnityEvent OnBreak;

    void Start()
    {
        foreach (GameObject obj in Breakables) 
            obj.SetActive(false);
    }


    public void Break()
    {
        timer += Time.deltaTime;
        if (timer > timeToBreak)
        {
            foreach (GameObject obj in Breakables)
            {
                obj.SetActive(true);
                obj.transform.parent = null;
            }

            OnBreak.Invoke();
            Destroy(gameObject);
        }
    }
}
