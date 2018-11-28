using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {

    public Image healthUI;
    public GameObject player;
    private Plane planeMoving;
    private int health;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        planeMoving = player.GetComponent<Plane>();
        health = planeMoving.health;
    }
	
	// Update is called once per frame
	void Update () {
        healthUI.rectTransform.localScale = new Vector3((float)planeMoving.health/health, healthUI.rectTransform.localScale.y);
    }
}
