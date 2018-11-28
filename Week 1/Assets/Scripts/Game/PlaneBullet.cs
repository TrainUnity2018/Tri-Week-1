using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBullet : Bullet {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "BorderUp")
        {
            Destroy(this.gameObject);
        }
        if (col.gameObject.tag == "EnemyPlane")
        {
            Destroy(this.gameObject);
            col.gameObject.GetComponent<EnemyPlane>().health -= damage;
        }
    }
}
