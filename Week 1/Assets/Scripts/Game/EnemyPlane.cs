﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlane : MonoBehaviour {

    public float speed;
    public int damage;
    public int health;

    public GameObject bulletUpgradeDrop;
    public GameObject bulletUpgradeDrop2;
    public GameObject armorDrop;
    public GameObject healthDrop;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        Die();
        Move();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bottom")
        {
            Destroy(this.gameObject);
        }

        if (col.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            if (col.gameObject.GetComponent<Plane>().armor > 0)
            {
                col.gameObject.GetComponent<Plane>().armor -= damage;
            }
            else
                col.gameObject.GetComponent<Plane>().health -= damage;
        }
    }

    void OnDestroy()
    {
        DropItem();
    }

    public virtual void Move()
    {
        this.transform.position -= new Vector3(0, (float)speed) * Time.deltaTime;
    }

    public virtual void DropItem()
    {
        int rand = (int)Random.Range(-3, 3);
        if (rand == 1)
        {
            Instantiate(bulletUpgradeDrop, this.transform.position, Quaternion.identity);
        }
        else if (rand == 2)
        {
            Instantiate(bulletUpgradeDrop2, this.transform.position, Quaternion.identity);
        }
        else if (rand == -2)
        {
            Instantiate(armorDrop, this.transform.position, Quaternion.identity);
        }
        else if (rand == 0)
        {
            Instantiate(healthDrop, this.transform.position, Quaternion.identity);
        }
    }

    public virtual void Die()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
