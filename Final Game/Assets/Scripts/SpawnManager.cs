using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Trump;
    public GameObject Coronavirus;
    public GameObject Powerup;

    private float zTrumpSpawn = 15.0f;
    private float xSpawnRange = 10.0f;
    private float zPowerupSpawn = 15.0f;
    private float zCoronavirusSpawn = 15.0f;
    private float ySpawn = 0.75f;

    private float trumpSpawnTime = 5.0f;
    private float coronavirusSpawnTime = 3.0f;
    private float powerupSpawnTime = 5.0f;
    private float startDelay = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnTrump", startDelay, trumpSpawnTime);
        InvokeRepeating("SpawnCoronavirus", startDelay, coronavirusSpawnTime);
        InvokeRepeating("SpawnPowerup", startDelay, powerupSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnTrump()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
    
        Vector3 spawnPos = new Vector3(randomX, ySpawn, zTrumpSpawn);

        Instantiate(Trump, spawnPos, Trump.gameObject.transform.rotation);
    }

    void SpawnCoronavirus()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);

        Vector3 spawnPos = new Vector3(randomX, ySpawn, zCoronavirusSpawn);

        Instantiate(Coronavirus, spawnPos, Coronavirus.gameObject.transform.rotation);
    }

    void SpawnPowerup()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);

        Vector3 spawnPos = new Vector3(randomX, ySpawn, zPowerupSpawn);

        Instantiate(Powerup, spawnPos, Powerup.gameObject.transform.rotation);
    }
}
