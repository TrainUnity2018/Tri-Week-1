using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMissileCollideRange : MonoBehaviour {

    public GameObject missile;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "EnemyPlane")
        {
            Destroy(missile.gameObject);
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "BorderUp")
        {
            Destroy(missile.gameObject);
        }
    }
}
