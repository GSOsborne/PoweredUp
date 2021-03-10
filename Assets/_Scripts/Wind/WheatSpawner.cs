using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheatSpawner : MonoBehaviour
{
    public float minX, maxX, minZ, maxZ;
    public GameObject wheatPrefab;
    public int wheatQuantity;
    // Start is called before the first frame update
    void Start()
    {
        SpawnWheat();
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WheatVision"))
        {
            Debug.Log("Oh wow a wheat spawner!");
            SpawnWheat();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("WheatVision"))
        {
            Debug.Log("So you're just gonna leave me here with my wheat alone? Fuck you.");
            DespawnWheat();
        }
    }
    */

    void SpawnWheat()
    {
        for (int i = 1; i < wheatQuantity; i++)
        {
            GameObject spawnedWheat = Instantiate(wheatPrefab, transform);
            spawnedWheat.transform.position = new Vector3(transform.position.x + Random.Range(minX, maxX), transform.position.y, transform.position.z + Random.Range(minZ, maxZ));
        }
    }

    void DespawnWheat()
    {
        foreach (Transform child in transform)
        {
            Debug.Log("Destroying: " + child.name);
            Destroy(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
