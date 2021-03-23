using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DSPGestureManager;

public class BriefCableReveal : MonoBehaviour
{
    Renderer rend;
    public Color deadColor;
    bool levelPassed;
    public float fadeInSpeed, hangTime, fadeOutSpeed;

    // Start is called before the first frame update
    void Start()
    {
        levelPassed = false;
        rend = GetComponent<Renderer>();
        DSPGestureManager.dspTriggered += BrieflyReveal;
    }

    void BrieflyReveal(DSPState givenState)
    {
        if (!levelPassed)
        {
            StopAllCoroutines();
            StartCoroutine(BrieflyFadeIn());
        }
    }

    IEnumerator BrieflyFadeIn()
    {
        //Debug.Log("Fading the cable in.");
        float aValue = rend.material.color.a;
        while (aValue < 1f)
        {
            aValue += Time.deltaTime * fadeInSpeed;
            rend.material.color = new Color(deadColor.r, deadColor.g, deadColor.b, aValue);
            yield return null;
        }
        //Debug.Log("Cable at full transparency.");
        yield return new WaitForSeconds(hangTime);
        while (aValue > 0f)
        {
            aValue -= Time.deltaTime * fadeOutSpeed;
            rend.material.color = new Color(deadColor.r, deadColor.g, deadColor.b, aValue);
            yield return null;
        }
        rend.material.color = new Color(deadColor.r, deadColor.g, deadColor.b, 0);
        //Debug.Log("Cable has been faded out.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
