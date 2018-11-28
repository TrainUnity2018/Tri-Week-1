using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLootManager : MonoBehaviour {
    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "UpgradeVertical")
        {
            this.gameObject.GetComponent<ShootVertical>().enable = true;
            this.gameObject.GetComponent<ShootCone>().enable = false;
        }
        if (col.gameObject.tag == "UpgradeCone")
        {
            this.gameObject.GetComponent<ShootVertical>().enable = false;
            this.gameObject.GetComponent<ShootCone>().enable = true;
        }
        if (col.gameObject.tag  == "Armor")
        {
            if (gameObject.GetComponent<Plane>().armor < 10)
            {
                gameObject.GetComponent<Plane>().armor += 1;
            }
        }
    }
}
