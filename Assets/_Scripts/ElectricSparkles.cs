using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricSparkles : MonoBehaviour
{
    ParticleSystem pStm;
    
    // Start is called before the first frame update
    void Start()
    {
        pStm = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GestureRadius"))
        {
            //Debug.Log("Woah, time for those beautiful sparkles already?");
            pStm.Play();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
