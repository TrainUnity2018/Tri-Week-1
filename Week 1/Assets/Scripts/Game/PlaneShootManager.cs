using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneShootManager : ShootManager {

    private int coneLevel;
    private int verticalLevel;
    public GameObject planeBulletConeLevel2;
    public GameObject planeBulletConeLevel3;
    public GameObject planeBulletConeLevel4;

    public GameObject planeBulletVerticalLevel2;
    public GameObject planeBulletVerticalLevel3;
    public GameObject planeBulletVerticalLevel4;


    // Use this for initialization
    void Start()
    {
        this.shoot = new Shoot(Resources.Load<GameObject>("PlaneBullet"), firePosition.transform, shootingDelay);
        this.shoot.Start();
        coneLevel = 1;
        verticalLevel = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (this.shoot != null)
        {
            this.shoot.Update();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "UpgradeCone")
        {
            coneLevel++;
            this.shoot = new ShootCone(bulletPrefab, planeBulletConeLevel2, planeBulletConeLevel3, planeBulletConeLevel4, firePosition.transform, shootingDelay, coneLevel);
            this.shoot.Start();
        }

        if (col.gameObject.tag == "UpgradeVertical")
        {
            verticalLevel++;
            this.shoot = new ShootVertical(bulletPrefab, planeBulletVerticalLevel2, planeBulletVerticalLevel3, planeBulletVerticalLevel4, firePosition.transform, shootingDelay, verticalLevel);
            this.shoot.Start();
        }
    }
}
