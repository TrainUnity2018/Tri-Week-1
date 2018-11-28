using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy;
    private float randX;
    private Vector3 whereToSpawn;

    public float spawnDelay = 5f;
    private float spawnDelayTimer;

    public float appearDelay = 0.5f;
    private float appearDelayTimer;

    public int spawnNumber;
    private int spawnCount;

    // Use this for initialization
    void Start () {
        spawnDelayTimer = 0;
        appearDelayTimer = 0;
        spawnCount = 0;
    }
	
	// Update is called once per frame
	void Update () {
        spawnDelayTimer += Time.deltaTime;
        
        if (spawnDelayTimer >= spawnDelay)
        {
            spawnDelayTimer = 0;
            spawnCount = 0;
        }
        Wave(spawnNumber);
	}

    public virtual void Spawn()
    {
        randX = Random.Range(-1.8f, 1.8f);
        whereToSpawn = new Vector3(randX, this.transform.position.y);
        Instantiate(enemy, whereToSpawn, Quaternion.identity);
    }

    public virtual void Wave(int spawnNumber)
    {
        if (spawnCount < spawnNumber)
        {
            appearDelayTimer += Time.deltaTime;
            if (appearDelayTimer >= appearDelay)
            {
                appearDelayTimer = 0;
                Spawn();
                spawnCount++;
            }
        }
    }
}
