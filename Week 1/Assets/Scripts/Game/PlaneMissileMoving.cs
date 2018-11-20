using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlaneMissileMoving : MonoBehaviour {

    private float speed = 1f;
    private float rotateSpeed = 200f;
    private Transform target;
    private Rigidbody2D rigidbody2D;
    
    // Use this for initialization
	void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("EnemyPlane").transform;
	}

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (Vector3)target.position - this.transform.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        rigidbody2D.angularVelocity = -rotateAmount * rotateSpeed;

        this.transform.position += this.transform.up * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "EnemyPlane")
        {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
    }
}
