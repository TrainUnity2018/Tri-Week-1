using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHealth : Item {
    
    public int health = 1;

    public override void OnCollide(Collider2D col)
    {
        base.OnCollide(col);

        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Plane>().LootHealth(health);
            Destroy(this.gameObject);
        }

    }
}
