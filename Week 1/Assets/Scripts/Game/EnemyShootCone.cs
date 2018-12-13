using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootCone : Shoot {

    protected Vector2[] level2Pos = { new Vector2((float)-0.2, -3), new Vector2((float)0.2, 3) };

    public EnemyShootCone(GameObject bulletPrefab, Transform firePosition, float shootingDelay)
    {
        this.bulletPrefab = bulletPrefab;
        this.firePosition = firePosition;
        this.shootingDelay = shootingDelay;
    }

    public override void Arrange()
    {
        for (int i = 0; i < level2Pos.Length; i++)
        {
            Shooting(firePosition, level2Pos[i].x, level2Pos[i].y, bulletPrefab);
        }
    }
}
