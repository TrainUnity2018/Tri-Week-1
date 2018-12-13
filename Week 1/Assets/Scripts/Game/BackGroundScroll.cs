using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroll : MonoBehaviour {

    Material material;
    Vector2 offset;

    public float velocityX, velocityY;
	
    private void Awake()
    {
        material = GetComponent<Renderer>().material;
    }
    
    // Use this for initialization
	void Start () {
        offset = new Vector2(velocityX, velocityY);
	}
	
	// Update is called once per frame
	void Update () {

        material.mainTextureOffset += offset * Time.deltaTime;
	}
}
