using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBulletMoving : MonoBehaviour {



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position -= new Vector3(0, (float)2f) * Time.deltaTime;
	}

    
}
