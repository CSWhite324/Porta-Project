using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    public GameObject cloud;
    [SerializeField] private float minSpawnInterval = 0.5f;
    [SerializeField] private float maxSpawnInterval = 3f;

    private float nextSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        // Set the first spawn time
        nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (CloudToggler.instance.clouds == true)
        {
            // Check if it's time to spawn a cloud
            if (Time.time >= nextSpawnTime)
            {
                // Spawn a cloud on a random side
                if (Random.Range(0, 2) == 0)
                {
                    SpawnCloudRight(cloud);
                }
                else
                {
                    SpawnCloudLeft(cloud);
                }

                // Set the next spawn time
                nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
            }
        }
    }

    private void SpawnCloudRight(GameObject c)
    {
        // Spawn cloud
        GameObject newCloud = Instantiate(c, new Vector3(5f, Random.Range(-2f, 4f)), Quaternion.identity);
        // Rotate cloud to point left
        newCloud.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
    }

    private void SpawnCloudLeft(GameObject c)
    {
        // Spawn cloud
        GameObject newCloud = Instantiate(c, new Vector3(-5f, Random.Range(-2f, 4f)), Quaternion.identity);
        // Rotate cloud to point right
        newCloud.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
    }
}