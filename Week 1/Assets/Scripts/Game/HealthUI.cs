using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {

    public Image healthUI;
    public GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        healthUI.rectTransform.localScale = new Vector3((float)player.GetComponent<Plane>().currentHealth / player.GetComponent<Plane>().initHealth, healthUI.rectTransform.localScale.y);
    }
}
