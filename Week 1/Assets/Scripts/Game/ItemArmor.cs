using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemArmor : Item {

    public int armor = 1;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "BorderDown")
        {
            Destroy(this.gameObject);
        }

        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Plane>().armor += armor;
            Destroy(this.gameObject);
        }

    }
}
