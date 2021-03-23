using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DSPGestureManager;

public class GestureRadiusController : MonoBehaviour
{

    public GameObject gestureRadius;

    // Start is called before the first frame update
    void Start()
    {
        gestureRadius.SetActive(false);
        DSPGestureManager.dspTriggered += BlipTheRadius;
    }

    void BlipTheRadius(DSPState givenState)
    {
        StopAllCoroutines();
        StartCoroutine(BlipItGood());

    }

    IEnumerator BlipItGood()
    {
        gestureRadius.SetActive(true);
        yield return null;
        gestureRadius.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
