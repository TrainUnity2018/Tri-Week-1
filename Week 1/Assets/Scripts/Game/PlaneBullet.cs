using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBullet : MonoBehaviour {

    public float speed = 5f;
    public int damage = 5;
    //public float rotateDegrees = 0f;
    //public float startPosition = 0;

    // Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        Move();
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
        }
    }

    public virtual void Move()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    public virtual void StartRotate(float rotateDegrees)
    {
        transform.eulerAngles = Vector3.forward * rotateDegrees;
    }

    public virtual void StartPosition (float startPosition)
    {
        transform.position += new Vector3((float)startPosition, 0);
    }
}
