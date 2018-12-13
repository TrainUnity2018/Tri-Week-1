using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootManager : ShootManager {

    // Use this for initialization
    void Start()
    {
        this.shoot = new EnemyShootCone(Resources.Load<GameObject>("EnemyBullet"), firePosition.transform, shootingDelay);
        this.shoot.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.shoot != null)
        {
            this.shoot.Update();
        }
    }
    
}
