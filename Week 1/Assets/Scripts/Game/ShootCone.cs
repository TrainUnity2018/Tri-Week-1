using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCone : Shoot
{
    public int level = 1;
    public GameObject bulletLevel2Prefab;
    public GameObject bulletLevel3Prefab;
    public GameObject bulletLevel4Prefab;
    private Vector2[] level2Pos = { new Vector2((float)-0.2, 3), new Vector2((float)0.2, -3) };
    private Vector2[] level3Pos = { new Vector2((float)-0.3, 5), new Vector2(0, 0), new Vector2((float)0.3, -5) };
    private Vector2[] level4Pos = { new Vector2((float)-0.6, 10), new Vector2((float)-0.2, 3), new Vector2((float)0.2, -3), new Vector2((float)0.6, -10) };

    void Start()
    {
        shootingDelayTimer = 0;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "UpgradeCone")
        {
            level++;
            this.gameObject.GetComponent<ShootVertical>().enable = false;
            this.gameObject.GetComponent<ShootCone>().enable = true;
        }
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
                Shooting(firePosition, level2Pos[i].x, level2Pos[i].y, bulletLevel2Prefab);
            }
        }
        else if (level >= 3 && level < 4)
        {
            for (int i = 0; i < level3Pos.Length; i++)
            {
                Shooting(firePosition, level3Pos[i].x, level3Pos[i].y, bulletLevel3Prefab);
            }
        }
        else if (level >= 4)
        {
            for (int i = 0; i < level4Pos.Length; i++)
            {
                Shooting(firePosition, level4Pos[i].x, level4Pos[i].y, bulletLevel4Prefab);
            }
        }
    }
}
