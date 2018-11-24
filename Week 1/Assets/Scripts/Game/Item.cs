using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public float speed = 2f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "BorderDown")
        {
            Destroy(this.gameObject);
        }

        if (col.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }

    public virtual void Move()
    {
        this.transform.position -= new Vector3(0, (float)speed) * Time.deltaTime;
    }
}
