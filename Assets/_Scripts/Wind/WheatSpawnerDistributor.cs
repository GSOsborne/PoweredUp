using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheatSpawnerDistributor : MonoBehaviour
{
    public GameObject wheatSpawnerPrefab;
    public int minX, maxX, minZ, maxZ;

    // Start is called before the first frame update
    void Start()
    {
        SpawnTheSpawners();
    }

    void SpawnTheSpawners()
    {
        //Debug.Log("Got here!");
        for (int i = minX; i < maxX; i = i+2)
        {
            //Debug.Log("I even got here.");
            for (int j = minZ; j < maxZ; j = j+2)
            {
                //Debug.Log("Holy shit i made it here, even.");
                GameObject wheatSpawner = Instantiate(wheatSpawnerPrefab, transform);
                wheatSpawner.transform.position = new Vector3(transform.position.x + i, transform.position.y, transform.position.x + j);
                //Debug.Log(wheatSpawner.transform.position);

            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
