using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2PlaneShooting : MonoBehaviour {

    public Transform firePosition1;
    public Transform firePosition2;
    public GameObject bulletPrefab;
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
        Instantiate(bulletPrefab, firePosition1.position, firePosition1.rotation);
        Instantiate(bulletPrefab, firePosition2.position, firePosition2.rotation);
    }
}
