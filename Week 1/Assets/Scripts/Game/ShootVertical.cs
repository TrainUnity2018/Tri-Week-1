using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootVertical : Shoot {

    private int level;
    private GameObject bulletLevel2Prefab;
    private GameObject bulletLevel3Prefab;
    private GameObject bulletLevel4Prefab;
    private float[] level2Pos = { (float)-0.4, (float)0.4 };
    private float[] level3Pos = { (float)-0.5, 0, (float)0.5};
    private float[] level4Pos = { (float)-1.2, (float)-0.5, (float)0.5, (float)1.2 };

    public ShootVertical(GameObject bulletPrefab, GameObject bulletLevel2Prefab, GameObject bulletLevel3Prefab, GameObject bulletLevel4Prefab, Transform firePosition, float shootingDelay, int level)
    {
        this.bulletPrefab = bulletPrefab;
        this.bulletLevel2Prefab = bulletLevel2Prefab;
        this.bulletLevel3Prefab = bulletLevel3Prefab;
        this.bulletLevel4Prefab = bulletLevel4Prefab;
        this.firePosition = firePosition;
        this.shootingDelay = shootingDelay;
        this.level = level;
    }

    public override void Arrange()
    {
        if (level >= 1 && level < 2)
        {
            Shooting(firePosition, 0, 0, bulletPrefab);
        }
        else if (level >= 2 && level < 3)
        {
            for (int i = 0; i < level2Pos.Length; i++)
            {
                Shooting(firePosition, level2Pos[i], 0, bulletLevel2Prefab);
            }
        }
        else if (level >= 3 && level < 4)
        {
            for (int i = 0; i < level3Pos.Length; i++)
            {
                if (i == 0 || i == 2)
                    Shooting(firePosition, level3Pos[i], 0, bulletPrefab);
                else
                    Shooting(firePosition, level3Pos[i], 0, bulletLevel3Prefab);
            }
        }
        else if (level >= 4)
        {
            for (int i = 0; i < level4Pos.Length; i++)
            {
                if (i == 0 || i == 3)
                    Shooting(firePosition, level4Pos[i], 0, bulletLevel2Prefab);
                else if (i == 1 || i == 2)
                    Shooting(firePosition, level4Pos[i], 0, bulletLevel4Prefab);
            }
        }
    }

    
}
