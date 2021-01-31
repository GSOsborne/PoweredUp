using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using static DragMovement;

public class DragWorldController : MonoBehaviour
{
    ActionBasedController xrController;
    public DragModelRotation dragModel;

    Vector3 lastFramePos;
    public bool isDragging;
   
    // Start is called before the first frame update
    void Start()
    {
        xrController = GetComponent<ActionBasedController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (xrController.selectInteractionState.activatedThisFrame) // we are dragging ourselves around with this controller
        {
            lastFramePos = transform.localPosition;
            dragModel.UnparentFromController();
            //Debug.Log("First frame position was " + lastFramePos);
        }
        if (xrController.selectInteractionState.deactivatedThisFrame) // we stopped dragging ourselves with the controller
        {
            dragModel.ParentToController();
        }


        if (xrController.selectInteractionState.active)
        {
            //Debug.Log("Grabbing the PHAT world with " + this.name);
            Vector3 sentVector = lastFramePos - transform.localPosition;
            DragMovement.Instance.RecieveMovementVector(sentVector);
            dragModel.TrackRotation(sentVector);
            lastFramePos = transform.localPosition;
            isDragging = true;
        }
        else
        {
            isDragging = false;
        }

        //Vector3 positionVector = xrController.positionAction.action.ReadValue<Vector3>();
        //Debug.Log(positionVector);
        
    }

}
