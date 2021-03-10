using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Formats.Alembic.Importer;


public class WheatTurn : MonoBehaviour
{
    AlembicStreamController bendController, idleController;
    public GameObject idleWheatObject, bendWheatObject;


    public float idleResetSpeed, idleEndTime, bendResetSpeed, bendLoopBeginTime, bendEndTime, rotationSpeed;

    bool stopBending;

    GameObject playerObject;

    // Start is called before the first frame update
    void Start()
    {
        idleWheatObject.SetActive(true);
        bendWheatObject.SetActive(false);
        stopBending = true;
        bendController = bendWheatObject.GetComponent<AlembicStreamController>();
        idleController = idleWheatObject.GetComponent<AlembicStreamController>();
        StartCoroutine(DelayStartOfIdleCycle());
    }

    IEnumerator DelayStartOfIdleCycle()
    {
        yield return new WaitForSeconds(Random.Range(0f, 2f));
        IdleWheat();
    }

    void IdleWheat()
    {
        idleWheatObject.SetActive(true);
        bendWheatObject.SetActive(false);
        StartCoroutine(IdleLoop());
    }

    IEnumerator IdleLoop()
    {
        float idleTimer = 0f;
        while (idleTimer < idleEndTime)
        {
            idleTimer += Time.deltaTime;
            if (idleTimer > idleEndTime)
            {
                idleTimer = 0f;
            }
            idleController.time = idleTimer;
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Player approaches! I must bend!");
            playerObject = other.gameObject;
            StartBend();
        }
    }

    void StartBend()
    {
        StopAllCoroutines();
        StartCoroutine(IdleBackToStraight());
    }

    IEnumerator IdleBackToStraight()
    {
        float timer = idleController.time;
        while (timer < idleEndTime)
        {
            timer += Time.deltaTime * idleResetSpeed;
            idleController.time = timer;

            yield return null;
        }
        //Debug.Log("Finished resetting idle animation!");
        StartBendLoop();
    }

    void StartBendLoop()
    {
        stopBending = false;
        idleWheatObject.SetActive(false);
        bendWheatObject.SetActive(true);
        StartCoroutine(BendLoop());
    }

    IEnumerator BendLoop()
    {
        float bendTimer = 0f;
        while (!stopBending)
        {
            while (bendTimer < bendEndTime)
            {
                if(bendTimer < bendLoopBeginTime)
                {
                    bendTimer += Time.deltaTime * 12;
                }
                else
                {
                    bendTimer += Time.deltaTime * 3;
                }

                bendController.time = bendTimer;
                yield return null;
            }
            while (bendTimer > bendLoopBeginTime)
            {
                bendTimer -= Time.deltaTime;
                bendController.time = bendTimer;
                yield return null;
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopBend();
        }
    }

    void StopBend()
    {
        StopAllCoroutines();
        stopBending = true;
        StartCoroutine(BendBackToStraight());
    }

    IEnumerator BendBackToStraight()
    {
        float bendTimer = bendController.time;
        while (bendTimer > 0f)
        {
            bendTimer -= Time.deltaTime * bendResetSpeed;
            bendController.time = bendTimer;
            yield return null;
        }
        IdleWheat();
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopBending)
        {
            // Determine which direction to rotate towards
            Vector3 targetDirection = playerObject.transform.position - transform.position;

            // The step size is equal to speed times frame time.
            float singleStep = rotationSpeed * Time.deltaTime;

            // Rotate the forward vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

            // Draw a ray pointing at our target in
            Debug.DrawRay(transform.position, newDirection, Color.red);

            // Calculate a rotation a step closer to the target and applies rotation to this object
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }
}


