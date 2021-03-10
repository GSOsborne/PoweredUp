using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheatEnabler : MonoBehaviour
{
    public GameObject wheatSpawner;
    // Start is called before the first frame update
    void Start()
    {
        wheatSpawner.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("WheatVision"))
        {
            wheatSpawner.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("WheatVision"))
        {
            wheatSpawner.SetActive(false);
        }
    }
}
