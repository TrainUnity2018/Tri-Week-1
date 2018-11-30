using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public Transform firePosition;
    public GameObject bulletPrefab;
    public float shootingDelay = 1f;
    protected float shootingDelayTimer;
    public bool enable = true;

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
            if (enable)
                Arrange();
        }
	}
    

    public virtual void Shooting (Transform pos, float startPosition, float rotateDegrees, GameObject bullet)
    {
        Vector3 position = pos.position;
        position += new Vector3(startPosition, 0);

        Quaternion rotate = pos.rotation;
        rotate = Quaternion.Euler(Vector3.forward * rotateDegrees);

        Instantiate(bullet, position, rotate);
    }

    public virtual void Arrange ()
    {
        Shooting(firePosition, 0, 0, bulletPrefab);
    }
}
