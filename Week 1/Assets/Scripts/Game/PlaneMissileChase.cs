using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMissileChase : MissileChase {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "EnemyPlane")
        {
            OnCollide(col);
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "EnemyPlane")
        {
            OnCollide(col);
        }
    }

    public virtual void OnCollide(Collider2D col)
    {
        FindRotateAngle(col.transform);
    }
}
