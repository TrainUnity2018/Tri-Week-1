﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1PlaneBulletMoving : MonoBehaviour {

    private float speed = 5f;
    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position += new Vector3(0, (float)speed) * Time.deltaTime;
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "BorderUp")
        {
            Destroy(this.gameObject);
        }
        if (col.gameObject.tag == "EnemyPlane")
        {
            Destroy(this.gameObject);
            Destroy(col.gameObject);
        }
    }
}
