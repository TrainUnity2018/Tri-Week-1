using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMissile : PlaneBullet {

    private float rotateSpeed = 5f;
    private Transform enemyTarget;

    // Update is called once per frame
    void Update()
    {
        try
        {
            enemyTarget = GameObject.FindGameObjectWithTag("EnemyPlane").transform;
        }
        catch (Exception e)
        {

        }

        if (enemyTarget != null)
        {
            Rotate();
        }

        Move();
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "EnemyPlane")
        {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }

        if (col.gameObject.tag == "Up")
        {
            Destroy(this.gameObject);
        }
    }

    public virtual void Rotate()
    {
        Vector3 direction = enemyTarget.position - this.transform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Slerp(transform.rotation, (Quaternion.AngleAxis(angle, Vector3.forward)), rotateSpeed * Time.deltaTime);
    }
}
