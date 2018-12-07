using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour {

    public GameObject firePosition;
    public float shootingDelay;
    public GameObject bulletPrefab;
    protected Shoot shoot;
    

	// Use this for initialization
	void Start () {
        this.shoot = new Shoot(bulletPrefab, firePosition.transform, shootingDelay);
        this.shoot.Start();
    }
	
	// Update is called once per frame
	void Update () {

        if (this.shoot != null)
        {
            this.shoot.Update();
        }
	}

}
