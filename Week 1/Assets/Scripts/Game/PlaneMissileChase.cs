using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMissileChase : MissileChase {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "EnemyPlane")
        {
            Rotate(col.transform);
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "EnemyPlane")
        {
            Rotate(col.transform);
        }
    }
}
