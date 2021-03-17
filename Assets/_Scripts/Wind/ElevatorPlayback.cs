using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Formats.Alembic.Importer;

public class ElevatorPlayback : MonoBehaviour
{
    AlembicStreamController abcController;
    public float loweredTime, raisedTime;

    public float raiseSpeed, lowerSpeed;

    // Start is called before the first frame update
    void Start()
    {
        abcController = GetComponent<AlembicStreamController>();
        abcController.time = loweredTime;
        LowerElevator();
    }

    public void RaiseElevator()
    {
        StopAllCoroutines();
        StartCoroutine(RaiseThatElevator());
    }

    IEnumerator RaiseThatElevator()
    {
       // Debug.Log("Raising that elevator.");
        float animTime = loweredTime;
        while (animTime < raisedTime)
        {
            Debug.Log(abcController.time + " is the time");
            animTime += Time.deltaTime * raiseSpeed;
            abcController.time = animTime;
            yield return null;
        }
        //Debug.Log("Done raising.");
    }

    public void LowerElevator()
    {
        StopAllCoroutines();
        StartCoroutine(LowerThatElevator());
    }

    IEnumerator LowerThatElevator()
    {
        //Debug.Log("Lowering the elevator.");
        float animTime = raisedTime;
        while (animTime > loweredTime)
        {
            animTime -= Time.deltaTime * lowerSpeed;
            abcController.time = animTime;
            yield return null;
        }
       // Debug.Log("Done lowering.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
