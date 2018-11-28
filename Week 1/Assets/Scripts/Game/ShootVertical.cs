using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootVertical : Shoot {

    public int level = 1;
    private float[] level2Pos = { (float)-0.4, (float)0.4 };
    private float[] level3Pos = { (float)-0.5, 0, (float)0.5};
    private float[] level4Pos = { (float)-0.6, (float)-0.2, (float)0.2, (float)0.6 };

    void Start()
    {
        shootingDelayTimer = 0;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "UpgradeVertical")
        {
            level++;
        }
    }

    public override void Arrange()
    {
        if (level >= 1 && level < 2)
        {
            Shooting(firePosition, 0, 0);
        }
        else if (level >= 2 && level < 3)
        {
            for (int i = 0; i < level2Pos.Length; i++)
            {
                Shooting(firePosition, level2Pos[i], 0);
            }
        }
        else if (level >= 3 && level < 4)
        {
            for (int i = 0; i < level3Pos.Length; i++)
            {
                Shooting(firePosition, level3Pos[i], 0);
            }
        }
        else if (level >= 4)
        {
            for (int i = 0; i < level4Pos.Length; i++)
            {
                Shooting(firePosition, level4Pos[i], 0);
            }
        }
    }
}
