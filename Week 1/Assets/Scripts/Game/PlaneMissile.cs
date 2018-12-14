using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMissile : Bullet {

    public float rotateSpeed = 8f;
    public GameObject missileChase;
    public GameObject missileCollider;

    void Start()
    {
        
    }

    void Update()
    {
        Move();
        Rotate(missileChase.GetComponent<PlaneMissileChase>().rotateAngle);
    }

    public virtual void Rotate(Quaternion rotateAngle)
    {
        this.gameObject.transform.rotation = rotateAngle;
        missileCollider.gameObject.transform.rotation = rotateAngle;
    }

    public override void OnCollide(Collider2D col)
    {

    }

    public override void OnExplode()
    {
        isExploded = true;
        animator.SetBool("isExploded", isExploded);
        missileCollider.GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 1);
    }
}
