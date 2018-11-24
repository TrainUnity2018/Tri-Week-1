using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    protected float speed = 5f;
    
    // Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        
    }

    public virtual void Move()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

}
