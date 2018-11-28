using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet {

    public override void Move()
    {
        transform.position -= transform.up * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "BorderDown")
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
}
