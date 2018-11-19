using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy;
    private float randX;
    private Vector3 whereToSpawn;
    private float spawningDelay = 2f;
    private float spawningDelayTimer;
    
    // Use this for initialization
	void Start () {
        spawningDelayTimer = 0;

    }
	
	// Update is called once per frame
	void Update () {
        spawningDelayTimer += Time.deltaTime;
        if (spawningDelayTimer >= spawningDelay)
        {
            spawningDelayTimer = 0;
            Spawn();
        }
	}

    void Spawn()
    {
        randX = Random.Range(-1.8f, 1.8f);
        whereToSpawn = new Vector3(randX, this.transform.position.y);
        Instantiate(enemy, whereToSpawn, Quaternion.identity);
    }
}
