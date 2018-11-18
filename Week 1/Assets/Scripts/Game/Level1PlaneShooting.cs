using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1PlaneShooting : MonoBehaviour {

    public Transform firePosition;
    public GameObject bulletPrefab;
    private float shootingDelay = 1f;
    private float shootingDelayTimer;
	
    void Start ()
    {
        shootingDelayTimer = 0;
    }
	
    // Update is called once per frame
	void Update () {
        //if (Input.GetKeyDown(KeyCode.C))
        //      {
        //          Shooting();
        //      }
        shootingDelayTimer += Time.deltaTime;
        if (shootingDelayTimer >= shootingDelay)
        {
            shootingDelayTimer = 0;
            Shooting();
        }
	}

    void Shooting ()
    {
        Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
    }
}
