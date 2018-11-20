using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMissileShooting : MonoBehaviour {

    public Transform firePosition;
    public GameObject bulletPrefab;
    private float shootingDelay = 2f;
    private float shootingDelayTimer;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        shootingDelayTimer += Time.deltaTime;
        if (shootingDelayTimer >= shootingDelay && Input.GetKeyDown(KeyCode.C))
        {
            shootingDelayTimer = 0;
            Shooting();
        }
    }

    void Shooting()
    {
        Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
    }
}
