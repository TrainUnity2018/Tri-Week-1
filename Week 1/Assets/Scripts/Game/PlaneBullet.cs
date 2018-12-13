using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBullet : Bullet {

    public override void OnCollide(Collider2D col)
    {
        base.OnCollide(col);

        if (col.gameObject.tag == "EnemyPlane")
        {
            Destroy(gameObject);
            col.gameObject.GetComponent<EnemyPlane>().TakeDamage(damage);
        }
    }

    public override void Rotate()
    {
        
    }
}
