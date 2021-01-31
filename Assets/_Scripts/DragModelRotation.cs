using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DragModelRotation : MonoBehaviour
{
    bool isDragging;
    Transform parentController;
    public float rotationSpeedMultiplier;

    
    // Start is called before the first frame update
    void Start()
    {
        parentController = gameObject.transform.parent;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ParentToController()
    {
        //Debug.Log("Parenting back to the controller");
        isDragging = false;
        transform.parent = parentController;
        transform.localPosition = new Vector3(0f, 0f, 0f);
    }

    public void UnparentFromController()
    {
        //Debug.Log("Rebellious teen phase activate!");
        isDragging = true;
        gameObject.transform.parent = null;
    }

    public void TrackRotation(Vector3 recievedVector)
    {
        //Debug.Log("recieved Vector magnitude is about: " + recievedVector.magnitude);
        

            Vector3 rotationAxis = Vector3.Cross(recievedVector, Vector3.down);
            transform.RotateAround(transform.position, rotationAxis, recievedVector.magnitude * rotationSpeedMultiplier);
    }

    public void TrackPosition()
    {
        transform.position = parentController.position;
    }
}
