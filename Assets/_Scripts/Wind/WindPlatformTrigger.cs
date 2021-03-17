using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindPlatformTrigger : MonoBehaviour
{
    public AK.Wwise.Event buildEvent;
    public GameObject xrRig;
    //Animator animator;
    public BigTurbinePlayer turbPlayer;
    public ElevatorPlayback elevPlayback;

    public float minHeight, maxHeight, raiseSpeed, lowerSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        //animator.speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            buildEvent.Post(this.gameObject);
            xrRig.transform.SetParent(transform);
            StartCoroutine(RaisePlatform());
            //animator.speed = 1;
            turbPlayer.FadeIn();
            elevPlayback.RaiseElevator();
        }
    }

    public void LowerThePlatform()
    {
        Debug.Log("Attempting to lower the platform now.");
        StopAllCoroutines();
        StartCoroutine(LowerPlatform());
        //animator.speed = -1f;
        
    }

    IEnumerator RaisePlatform()
    {
        Debug.Log("Starting to raise that platform.");
        float yValue = transform.position.y;
        while (yValue < maxHeight)
        {
            yValue += Time.deltaTime * raiseSpeed;
            transform.position = new Vector3(transform.position.x, yValue, transform.position.z);
            yield return null;
        }
    }

    IEnumerator LowerPlatform()
    {
        float yValue = transform.position.y;
        while (yValue > 0f)
        {
            yValue -= Time.deltaTime * lowerSpeed;
            transform.position = new Vector3(transform.position.x, yValue, transform.position.z);
            yield return null;
        }
        elevPlayback.LowerElevator();
    }
}
