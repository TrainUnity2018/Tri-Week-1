using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour {

    public GameObject player;
    private Shoot shoot;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        this.shoot = new ShootCone();
        this.shoot.Start();

        player = Resources.Load<GameObject>("Armor");

       

    }
	
	// Update is called once per frame
	void Update () {
		if(this.shoot != null)
        {
            this.shoot.Update();

        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {

    }
}
