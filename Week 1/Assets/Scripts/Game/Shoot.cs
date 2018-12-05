using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot {

    protected Transform firePosition;
    protected GameObject bulletPrefab;
    protected float shootingDelay;
    protected float shootingDelayTimer;

    public Shoot() {

    }

    public Shoot(GameObject bulletPrefab, Transform firePosition, float shootingDelay)
    {
        this.bulletPrefab = bulletPrefab;
        this.firePosition = firePosition;
        this.shootingDelay = shootingDelay;
    }

    public virtual void Start ()
    {
        shootingDelayTimer = 0;
    }

    // Update is called once per frame
    public virtual void Update () {
        
        shootingDelayTimer += Time.deltaTime;
        if (shootingDelayTimer >= shootingDelay)
        {
            shootingDelayTimer = 0;
            Arrange();
        }
	}
    
    public virtual void Shooting (Transform pos, float startPosition, float rotateDegrees, GameObject bullet)
    {
        Vector3 position = pos.position;
        position += new Vector3(startPosition, 0);

        Quaternion rotate = pos.rotation;
        rotate = Quaternion.Euler(Vector3.forward * rotateDegrees);

        //Instantiate(bullet, position, rotate);
        bullet = GameObject.Instantiate(bullet, position, rotate) as GameObject;
    }

    public virtual void Arrange ()
    {
        Shooting(firePosition, 0, 0, bulletPrefab);
    }
}
