using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawn : MonoBehaviour
{
    public GameObject Drop;
    public bool StopSpawning = false;
    public float spawnTime;
    public float spawnDelay;



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    public void SpawnObject ()
    {
        Instantiate(Drop, transform.position, transform.rotation);
        if (StopSpawning)
        {
            CancelInvoke("SpawnObject");
        }

    }
}
