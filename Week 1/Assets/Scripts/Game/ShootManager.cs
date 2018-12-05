using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour {

    public GameObject firePosition;
    public float shootingDelay;
    private Shoot shoot;
    private int coneLevel;
    private int verticalLevel;

	// Use this for initialization
	void Start () {
        this.shoot = new Shoot(Resources.Load<GameObject>("PlaneBullet"), firePosition.transform, shootingDelay);
        this.shoot.Start();
        coneLevel = 1;
        verticalLevel = 1;
    }
	
	// Update is called once per frame
	void Update () {

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
            this.shoot = new ShootCone(Resources.Load<GameObject>("PlaneBullet"), Resources.Load<GameObject>("PlaneBulletConeLevel2"), Resources.Load<GameObject>("PlaneBulletConeLevel3"), Resources.Load<GameObject>("PlaneBulletConeLevel4"), firePosition.transform, shootingDelay, coneLevel);
            this.shoot.Start();
        }

        if (col.gameObject.tag == "UpgradeVertical")
        {
            verticalLevel++;
            this.shoot = new ShootVertical(Resources.Load<GameObject>("PlaneBullet"), Resources.Load<GameObject>("PlaneBulletVerticalLevel2"), Resources.Load<GameObject>("PlaneBulletVerticalLevel3"), Resources.Load<GameObject>("PlaneBulletVerticalLevel4"), firePosition.transform, shootingDelay, verticalLevel);
            this.shoot.Start();
        }
    }
}
