using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMissileMoving : MonoBehaviour {

    private float speed = 5f;
    private float rotateSpeed = 5f;
    private Transform enemyTarget;

    
    // Use this for initialization
	void Start () {
    }

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
        
        //enemyTarget = GameObject.FindGameObjectWithTag("EnemyPlane").transform;

        if (enemyTarget != null)
        {
            Vector3 direction = enemyTarget.position - this.transform.position;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.Slerp(transform.rotation, (Quaternion.AngleAxis(angle, Vector3.forward)), rotateSpeed * Time.deltaTime);
        }
        
        this.transform.position += this.transform.up * speed * Time.deltaTime;

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

    
}
