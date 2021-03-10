using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DSPGestureManager;

public class DSPController : MonoBehaviour
{
    public DragWorldController dragWorldLeft, dragWorldRight;
    public float triggerSpeed = 1f;
    LayerMask layerMask;
    RaycastHit hit;
    bool resetting;

    Vector3 lastFramePos;
    // Start is called before the first frame update
    void Start()
    {
        
        layerMask = LayerMask.GetMask("DSPTrigger");
        Debug.Log("Layer mask is: " + layerMask.value);
        resetting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dragWorldRight.isDragging && !dragWorldLeft.isDragging && !resetting)
        {
            //Debug.Log("speed is: " + (lastFramePos - transform.localPosition).magnitude*1000);
            if ((lastFramePos - transform.position).magnitude * 1000 > triggerSpeed)
            {
                //Ray ray = new Ray(transform.localPosition, transform.localPosition - lastFramePos);
                Debug.DrawRay(transform.position, (transform.position - lastFramePos)*20, Color.green, 2f);
                Debug.Log("Speed check passed, checking for DSP Wall.");
                if (Physics.Raycast(transform.position, transform.position-lastFramePos, out hit, 20f, layerMask))
                {
                    Debug.Log("Hit the wall: " + hit.transform.gameObject);
                    DSPTriggerWall hitWall = hit.transform.gameObject.GetComponent<DSPTriggerWall>();
                    DSPGestureManager.Instance.TriggerDSPSwitch(hitWall.dspState);
                }



            }
        }
        lastFramePos = transform.position;
    }

    IEnumerator ResetGesture()
    {
        resetting = true;
        yield return new WaitForSeconds(.5f);
        resetting = false;
    }
}
