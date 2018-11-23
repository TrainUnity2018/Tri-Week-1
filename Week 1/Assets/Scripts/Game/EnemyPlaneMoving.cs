using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlaneMoving : MonoBehaviour {

    private float speed = 0.01f;
    public GameObject upgradeDrop;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position -= new Vector3(0, (float)speed);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bottom")
        {
            Destroy(this.gameObject);
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
}
