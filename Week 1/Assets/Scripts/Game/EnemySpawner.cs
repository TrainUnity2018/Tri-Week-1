using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy;
    public GameObject enemyShooting;
    public GameObject enemyHorizontal;
    private float randX;
    private int rand;
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
        rand = Random.Range(-2, 2);
        if (rand == 0)
            Instantiate(enemy, whereToSpawn, enemy.transform.rotation);
        else if (rand == 1)
            Instantiate(enemyShooting, whereToSpawn, enemyShooting.transform.rotation);
        else if (rand == -1)
        {
            Instantiate(enemyHorizontal, whereToSpawn, enemyHorizontal.transform.rotation);
        }
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
