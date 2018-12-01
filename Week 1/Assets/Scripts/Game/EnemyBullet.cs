using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet {

    public override void Move()
    {
        transform.position -= transform.up * speed * Time.deltaTime;
    }

    public override void OnCollide(Collider2D col)
    {
        base.OnCollide(col);

        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            col.gameObject.GetComponent<Plane>().TakeDamage(damage);
        }
    }
}
