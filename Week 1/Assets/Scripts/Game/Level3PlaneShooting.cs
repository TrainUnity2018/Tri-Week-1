using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3PlaneShooting : MonoBehaviour {

    public Transform firePosition1;
    public Transform firePosition2;
    public Transform firePosition3;
    public GameObject bulletPrefab1;
    public GameObject bulletPrefab2;
    public GameObject bulletPrefab3;
    private float shootingDelay = 1f;
    private float shootingDelayTimer;

    // Use this for initialization
    void Start () {
        shootingDelayTimer = 0;
    }
	
	// Update is called once per frame
	void Update () {
        shootingDelayTimer += Time.deltaTime;
        if (shootingDelayTimer >= shootingDelay)
        {
            shootingDelayTimer = 0;
            Shooting();
        }
    }

    void Shooting()
    {
        Instantiate(bulletPrefab1, firePosition1.position, firePosition1.rotation);
        Instantiate(bulletPrefab2, firePosition2.position, firePosition2.rotation);
        Instantiate(bulletPrefab3, firePosition3.position, firePosition3.rotation);
    }
}
