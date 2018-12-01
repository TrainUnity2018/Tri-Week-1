using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed;
    public int damage;
    
    // Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        OnCollide(col);
    }

    public virtual void Move()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    public virtual void OnCollide(Collider2D col)
    {
        if (col.gameObject.tag == "BorderUp")
            Destroy(gameObject);
    }
}
