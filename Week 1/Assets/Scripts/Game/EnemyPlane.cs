using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlane : MonoBehaviour {

    public float speed;
    public int damage;
    public int health;

    public GameObject bulletUpgradeDrop;
    public GameObject bulletUpgradeDrop2;
    public GameObject armorDrop;
    public GameObject healthDrop;

    protected bool isExploded;
    public Animator animator;

    // Use this for initialization
    void Start () {
        isExploded = false;
	}

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        OnCollide(col);
    }

    void OnDestroy()
    {
        DropItem();
    }

    public virtual void Move()
    {
        if (!isExploded)
            this.transform.position -= new Vector3(0, (float)speed) * Time.deltaTime;
    }

    public virtual void OnCollide(Collider2D col)
    {
        if (col.gameObject.tag == "Bottom")
        {
            Destroy(this.gameObject);
        }

        if (col.gameObject.tag == "Player" && !isExploded)
        {
            OnExplode();
            col.gameObject.GetComponent<Plane>().TakeDamage(damage);
        }
        
    }

    public virtual void OnExplode()
    {
        isExploded = true;
        animator.SetBool("isExploded", isExploded);
        gameObject.GetComponent<Collider2D>().enabled = false;
        if (gameObject.GetComponent<ShootManager>() != null)
            gameObject.GetComponent<ShootManager>().enabled = false;
        Destroy(gameObject, 1);
    }

    public virtual void DropItem()
    {
        int rand = (int)Random.Range(-3, 3);
        if (rand == 1)
        {
            Instantiate(bulletUpgradeDrop, this.transform.position, Quaternion.identity);
        }
        else if (rand == 2)
        {
            Instantiate(bulletUpgradeDrop2, this.transform.position, Quaternion.identity);
        }
        else if (rand == -2)
        {
            Instantiate(armorDrop, this.transform.position, Quaternion.identity);
        }
        else if (rand == 0)
        {
            Instantiate(healthDrop, this.transform.position, Quaternion.identity);
        }
    }

    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            OnExplode();
    }

}
