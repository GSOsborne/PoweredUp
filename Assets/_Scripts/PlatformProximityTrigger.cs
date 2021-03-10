using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK.Wwise;

public class PlatformProximityTrigger : MonoBehaviour
{

    public AK.Wwise.Event enterEvent, exitEvent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enterEvent.Post(this.gameObject);
            Debug.Log("Setting layer " + enterEvent);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            exitEvent.Post(this.gameObject);
            Debug.Log("Setting layer " + exitEvent);
        }
    }
}
