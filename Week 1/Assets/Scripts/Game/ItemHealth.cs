using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHealth : Item {
    
    public int health = 1;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "BorderDown")
        {
            Destroy(this.gameObject);
        }

        if (col.gameObject.tag == "Player")
        {
            if (col.gameObject.GetComponent<Plane>().health + health <= 5)
                col.gameObject.GetComponent<Plane>().health += health;
            else
            {
                col.gameObject.GetComponent<Plane>().health = 5;
            }
            Destroy(this.gameObject);
        }

    }
}
