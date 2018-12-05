using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMissileShooting : Shoot {

	// Update is called once per frame
	public override void Update () {
        shootingDelayTimer += Time.deltaTime;
        if (shootingDelayTimer >= shootingDelay && Input.GetKeyDown(KeyCode.C))
        {
            shootingDelayTimer = 0;
            if (Input.GetKeyDown(KeyCode.C))
            {
                Arrange();
            }
        }
    }
}
