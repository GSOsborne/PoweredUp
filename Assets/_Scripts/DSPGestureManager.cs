using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DSPGestureManager : MonoBehaviour
{
    public AK.Wwise.Event chorusDSP, distortionDSP, echoDSP, tremeloDSP, extraHarmonyOn, extraHarmonyOff;
    public enum DSPState
    {
        Chorus, Distortion, Echo, Tremelo
    }

    public static System.Action<DSPState> dspTriggered;

    public float harmonyTime;

    public static DSPGestureManager Instance;
    public DSPState currentDSPState;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerDSPSwitch(DSPState givenDSP)
    {
        Debug.Log("Got a DSP trigger for: " + givenDSP);
        dspTriggered.Invoke(givenDSP);
        switch (givenDSP)
        {
            case DSPState.Chorus:
                chorusDSP.Post(this.gameObject);
                break;
            case DSPState.Distortion:
                distortionDSP.Post(this.gameObject);
                break;
            case DSPState.Echo:
                echoDSP.Post(this.gameObject);
                break;
            case DSPState.Tremelo:
                tremeloDSP.Post(this.gameObject);
                break;
        }
        StopAllCoroutines();
        StartCoroutine(BrieflyEnableHarmony());
    }

    IEnumerator BrieflyEnableHarmony()
    {
        extraHarmonyOn.Post(this.gameObject);
        yield return new WaitForSeconds(harmonyTime);
        extraHarmonyOff.Post(this.gameObject);
    }
}
