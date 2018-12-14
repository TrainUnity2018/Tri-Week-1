using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMissileCollideRange : Bullet {

    public GameObject missile;

    void Update()
    {
        
    }

    public override void OnCollide(Collider2D col)
    {
        if (col.gameObject.tag == "EnemyPlane" && !isExploded)
        {
            missile.GetComponent<PlaneMissile>().OnExplode();
            col.gameObject.GetComponent<EnemyPlane>().OnExplode();
        }
    }
}
