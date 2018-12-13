using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed;
    public int damage;
    protected bool isExploded;
    public Animator animator;
    
    // Use this for initialization
	void Start () {
        isExploded = false;
    }
	
	// Update is called once per frame
	void Update () {
        Move();
        Rotate();
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        OnCollide(col);
    }

    public virtual void Move()
    {
        if (!isExploded)
            transform.position += transform.up * speed * Time.deltaTime;
    }

    public virtual void Rotate()
    {

    }

    public virtual void OnExplode()
    {
        isExploded = true;
        animator.SetBool("isExploded", isExploded);
        gameObject.GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 1);
    }

    public virtual void OnCollide(Collider2D col)
    {
        if (col.gameObject.tag == "BorderUp")
            Destroy(gameObject);
    }
}
