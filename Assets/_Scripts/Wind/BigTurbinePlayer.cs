using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Formats.Alembic.Importer;
using static DSPGestureManager;

public class BigTurbinePlayer : MonoBehaviour
{

    public Renderer turbineMatRenderer;
    public AlembicStreamController turbineController;

    public AK.Wwise.Event triumphEvent;

    public float fadeSpeed;
    public float assemblyBuiltTime, loopBeginTime, loopEndTime;
    public float buildSpeed;
    public float loopSpeed;

    public bool buildSpeedBoosted;

    // Start is called before the first frame update
    void Start()
    {
        turbineController.time = 0f;
        turbineMatRenderer.sharedMaterial.color = new Color(Color.white.a, Color.white.g, Color.white.b, 0);
        DSPGestureManager.dspTriggered += BoostBuildSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeIn()
    {
        //Debug.Log("Oh, its time to start the shooooooooow!");
        StartCoroutine(FadeInRoutine());
        StartCoroutine(AssembleTheTurbine());
    }

    IEnumerator FadeInRoutine()
    {
       // Debug.Log("Starting that fade in coroutine!");
        float transparency = 0;
        while (transparency < 1)
        {
            //Debug.Log("Transparency should be at: " + transparency);
            transparency += fadeSpeed * Time.deltaTime;
            turbineMatRenderer.sharedMaterial.color = new Color(Color.white.r, Color.white.g, Color.white.b, transparency);
            yield return null;
        }
        turbineMatRenderer.sharedMaterial.color = new Color(Color.white.r, Color.white.g, Color.white.b, 1);
    }

    IEnumerator AssembleTheTurbine()
    {
        bool triumphPosted = false;
        float assemblyTimer = 0f;
        while (assemblyTimer < assemblyBuiltTime)
        {
            turbineController.time = assemblyTimer;

            if (buildSpeedBoosted)
            {
                assemblyTimer += Time.deltaTime * buildSpeed*4;
            }
            else
            {
                assemblyTimer += Time.deltaTime * buildSpeed;
            }
            //Debug.Log("Turbine assembly should be at the time of: " + assemblyTimer);
            yield return null;
        }
        turbineController.time = assemblyBuiltTime;
        while(assemblyTimer < loopEndTime)
        {
            turbineController.time = assemblyTimer;
            assemblyTimer += Time.deltaTime * loopSpeed;
            if (assemblyTimer > loopEndTime)
            {
                assemblyTimer = loopBeginTime;

                if (!triumphPosted)
                {
                    triumphEvent.Post(this.gameObject);
                    triumphPosted = true;
                }
            }
            //Debug.Log("Turbine loop should be at the time of: " + assemblyTimer);
            yield return null;
        }


    }

    void BoostBuildSpeed(DSPState givenState)
    {
        StopCoroutine(TemporarilyBoostBuildSpeed());
        StartCoroutine(TemporarilyBoostBuildSpeed());
    }

    IEnumerator TemporarilyBoostBuildSpeed()
    {
        buildSpeedBoosted = true;
        yield return new WaitForSeconds(3f);
        buildSpeedBoosted = false;

    }
}
