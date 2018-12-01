using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemArmor : Item {

    public int armor = 1;

    public override void OnCollide(Collider2D col)
    {
        base.OnCollide(col);

        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Plane>().LootArmor(armor);
            Destroy(this.gameObject);
        }

    }
}
