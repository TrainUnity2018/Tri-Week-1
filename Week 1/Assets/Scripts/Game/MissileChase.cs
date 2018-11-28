using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileChase : MonoBehaviour {

    private float rotateSpeed = 8f;
    public GameObject missile;
    public GameObject missileCollideRange;

    // Use this for initialization
    void Start () {
		
	}

    void Update()
    {

    }

    public virtual void Rotate(Transform enemyTarget)
    {
        Vector3 direction = enemyTarget.position - this.transform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Slerp(transform.rotation, (Quaternion.AngleAxis(angle, Vector3.forward)), rotateSpeed * Time.deltaTime);
        missile.transform.rotation = Quaternion.Slerp(missile.transform.rotation, (Quaternion.AngleAxis(angle, Vector3.forward)), rotateSpeed * Time.deltaTime);
        missileCollideRange.transform.rotation = Quaternion.Slerp(missile.transform.rotation, (Quaternion.AngleAxis(angle, Vector3.forward)), rotateSpeed * Time.deltaTime);
    }
}
