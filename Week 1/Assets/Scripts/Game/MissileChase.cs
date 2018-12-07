using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileChase : MonoBehaviour {

    private float rotateSpeed = 8f;
    public Quaternion rotateAngle;

    // Use this for initialization
    void Start () {
		
	}

    void Update()
    {
        
    }

    public virtual void FindRotateAngle(Transform enemyTarget)
    {
        Vector3 direction = enemyTarget.position - this.transform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        rotateAngle = Quaternion.Slerp(transform.rotation, (Quaternion.AngleAxis(angle, Vector3.forward)), rotateSpeed * Time.deltaTime);
    }
}
