using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneShooting : MonoBehaviour {

    public Transform firePosition;
    public GameObject bulletPrefab;
    private int level = 1;
    private float shootingDelay = 1f;
    private float shootingDelayTimer;
    private float[] level2Pos = { (float)-0.5, (float)0.5 };
    private Vector2[] level3Pos = { new Vector2((float)-0.7, 10), new Vector2((float)0, 0), new Vector2((float)0.7, -10) };
    //rivate int[] level3Degree = { 30, 0, -30 };

    void Start ()
    {
        shootingDelayTimer = 0;
    }
	
    // Update is called once per frame
	void Update () {
        
        shootingDelayTimer += Time.deltaTime;
        if (shootingDelayTimer >= shootingDelay)
        {
            shootingDelayTimer = 0;
            if (level == 1)
            {
                Shooting(bulletPrefab, firePosition);
            }
            else if (level == 2)
            {
                for (int i = 0; i < level2Pos.Length; i++)
                {
                    GameObject bullet = bulletPrefab;
                    bullet.GetComponent<PlaneBullet>().StartPosition(level2Pos[i]);
                    Shooting(bullet, firePosition);
                }
            }
            else if (level == 3)
            {
                for (int i = 0; i < level3Pos.Length; i++)
                {
                    GameObject bullet = bulletPrefab;
                    bullet.GetComponent<PlaneBullet>().StartPosition(level3Pos[i].x);
                    bullet.GetComponent<PlaneBullet>().StartRotate(level3Pos[i].y);
                    Shooting(bullet, firePosition);
                }
            }
        }

        
	}
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Upgrade")
        {
            level++;
        }
    }

    void Shooting (GameObject bullet, Transform pos)
    {
        Instantiate(bullet, pos.position, pos.rotation);
    }
}
