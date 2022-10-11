using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;

    float distanceToNextSpawn;
    float distanceSinceLastSpawn = 0.0f;
    float distanceOfLastSpawn;


    public float minSpawnDistance = 0.5f;
    public float maxSpawnDistance = 3.0f;

    void Start()
    {
        distanceToNextSpawn = Random.Range(minSpawnDistance, maxSpawnDistance);
        distanceOfLastSpawn = transform.position.x;
    }

    void Update()
    {

        distanceSinceLastSpawn = transform.position.x - distanceOfLastSpawn;

        if (distanceSinceLastSpawn > distanceToNextSpawn)
        {
            int selection = Random.Range(0, objectsToSpawn.Length);

            Instantiate(objectsToSpawn[selection], transform.position, Quaternion.identity);

            distanceToNextSpawn = Random.Range(minSpawnDistance, maxSpawnDistance);
            distanceOfLastSpawn = transform.position.x;
            distanceSinceLastSpawn = 0.0f;
        }
    }
}
