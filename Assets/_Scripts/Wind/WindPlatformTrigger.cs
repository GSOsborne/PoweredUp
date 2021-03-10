using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindPlatformTrigger : MonoBehaviour
{
    public AK.Wwise.Event buildEvent;
    public GameObject xrRig;
    Animator animator;
    public BigTurbinePlayer turbPlayer;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.speed = 0;
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
            animator.speed = 1;
            turbPlayer.FadeIn();
        }
    }
}
