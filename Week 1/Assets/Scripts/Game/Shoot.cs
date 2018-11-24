using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public Transform firePosition;
    public GameObject bulletPrefab;
    private int level = 1;
    private float shootingDelay = 1f;
    private float shootingDelayTimer;
    private float[] level2Pos = { (float)-0.5, (float)0.5 };
    private Vector2[] level3Pos = { new Vector2((float)-0.7, 5), new Vector2((float)0, 0), new Vector2((float)0.7, -5) };

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
            Arrange();
        }
	}
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Upgrade")
        {
            level++;
        }
    }

    public virtual void Shooting (Transform pos, float startPosition, float rotateDegrees)
    {
        Vector3 position = pos.position;
        position += new Vector3(startPosition, 0);

        Quaternion rotate = pos.rotation;
        rotate = Quaternion.Euler(Vector3.forward * rotateDegrees);

        Instantiate(bulletPrefab, position, rotate);
    }

    public virtual void Arrange ()
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
        else if (level >= 3)
        {
            for (int i = 0; i < level3Pos.Length; i++)
            {
                Shooting(firePosition, level3Pos[i].x, level3Pos[i].y);
            }
        }
    }
}
