using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlane : MonoBehaviour {

    public float speed = 5f;
    public float damage = 1;

    public GameObject upgradeDrop;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bottom")
        {
            Destroy(this.gameObject);
        }

        if (col.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            col.gameObject.GetComponent<PlaneMoving>().health -= (int)damage;
        }
    }

    void OnDestroy()
    {
        int rand = (int)Random.Range(-1, 2);
        if (rand == 1)
        {
            Instantiate(upgradeDrop, this.transform.position, Quaternion.identity);
        }
    }

    public virtual void Move()
    {
        this.transform.position -= new Vector3(0, (float)speed) * Time.deltaTime;
    }
}
