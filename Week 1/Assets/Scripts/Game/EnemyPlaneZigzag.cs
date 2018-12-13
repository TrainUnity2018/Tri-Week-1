using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlaneZigzag : EnemyPlane {

    public Vector3 zigzagRight;
    public Vector3 zigzagLeft;
    public float stateTimerDelay;
    private float stateTimer;
    private int count;
    
    void Start()
    {
        stateTimer = 0;
        count = 0;
    }

    public override void Move()
    {
        stateTimer += Time.deltaTime;
        if (stateTimer >= stateTimerDelay)
        {
            stateTimer = 0;
            count++;
            if (count == 4) count = 0;
        }

        if (count == 1)
        {
            this.transform.position += zigzagRight * Time.deltaTime;
        }
        else if (count == 3)
        {
            this.transform.position += zigzagLeft * Time.deltaTime;
        }
        else if (count == 0 || count == 2) this.transform.position -= new Vector3(0, (float)speed) * Time.deltaTime;
    }
}
