using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3PlaneBulletMoving1 : MonoBehaviour {

    private float speed = 0.05f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position += new Vector3((float)-(speed / 10), (float)speed);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "BorderUp")
        {
            Destroy(this.gameObject);
        }
        if (col.gameObject.tag == "EnemyPlane")
        {
            Destroy(this.gameObject);
            Destroy(col.gameObject);
        }
    }
}
