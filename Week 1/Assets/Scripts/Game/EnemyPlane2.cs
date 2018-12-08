﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlane2 : EnemyPlane {

    protected float horizontalMove = 0.01f;
    public float horizontalMoveSpeed;
    private Vector3 horizontalVelocity;
    private bool state;
    public float stateTimerDelay;
    protected float stateTimer;
    private bool state2;
    private int count;

    void Start()
    {
        // horizontalMove = horizontalMoveSpeed;
        horizontalVelocity = new Vector3(0, 0);
        state = false;
        state2 = false;
        stateTimer = 0;
        count = 0;
    }

    public override void Move()
    {
        stateTimer += Time.deltaTime;
        if (stateTimer >= stateTimerDelay)
        {
            stateTimer = 0;
            state = !state;
            count++;
            if (count == 2 || count == 4) {

                state2 = !state2;
                //horizontalVelocity = new Vector3(0, 0);
            }
            
            if (count == 4) count = 0; 
        }
        if (state2 == false)
        {
            if (state == false)
            {
                horizontalVelocity -= new Vector3((float)horizontalMove, 0) * Time.deltaTime;
            }
            else if (state == true)
            {
                horizontalVelocity += new Vector3((float)horizontalMove, 0) * Time.deltaTime;
            }
        }
        else
        {
            if (state == false)
            {
                horizontalVelocity += new Vector3((float)horizontalMove, 0) * Time.deltaTime;
            }
            else if (state == true)
            {
                horizontalVelocity -= new Vector3((float)horizontalMove, 0) * Time.deltaTime;
            }
        }
        this.transform.position -= new Vector3(0, (float)speed) * Time.deltaTime;
        this.transform.position += horizontalVelocity;
    }
}