using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMoving : MonoBehaviour {

    private float speed = 0.1f;
    public int health = 5;


    private Vector3 velocityU = new Vector3(0, 0);
    private Vector3 velocityD = new Vector3(0, 0);
    private Vector3 velocityL = new Vector3(0, 0);
    private Vector3 velocityR = new Vector3(0, 0);
    private bool hitBorderU = false;
    private bool hitBorderD = false;
    private bool hitBorderL = false;
    private bool hitBorderR = false;
    
    private ColliderDistance2D coldist;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow))
        {
            velocityL -= new Vector3((float)speed, 0) * Time.deltaTime;
            if (!hitBorderL)
            {
                this.transform.position += velocityL;
            }
        }
        else
        {
            if (velocityL.x > 0)
            {
                velocityL = Vector3.zero;
            }
            if (velocityL != Vector3.zero)
            {
                velocityL += new Vector3((float)speed, 0) * Time.deltaTime;
                if (!hitBorderL)
                {
                    this.transform.position += velocityL;
                }
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            velocityR += new Vector3((float)speed, 0) * Time.deltaTime;
            if (!hitBorderR)
            {
                this.transform.position += velocityR;
            }
        }
        else
        {
            if (velocityR.x < 0)
            {
                velocityR = Vector3.zero;
            }
            if (velocityR != Vector3.zero)
            {
                velocityR -= new Vector3((float)speed, 0) * Time.deltaTime;
                if (!hitBorderR)
                {
                    this.transform.position += velocityR;
                }
            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            velocityD -= new Vector3(0, (float)speed) * Time.deltaTime;
            if (!hitBorderD)
            {
                this.transform.position += velocityD;
            }
        }
        else
        {
            if (velocityD.y > 0)
            {
                velocityD = Vector3.zero;
            }
            if (velocityD != Vector3.zero)
            {
                velocityD += new Vector3(0, (float)speed) * Time.deltaTime;
                if (!hitBorderD)
                {
                    this.transform.position += velocityD;
                }
            }
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocityU += new Vector3(0, (float)speed) * Time.deltaTime;
            if (!hitBorderU)
            {
                this.transform.position += velocityU;
            }
        }
        else
        {
            if (velocityU.y < 0)
            {
                velocityU = Vector3.zero;
            }
            if (velocityU != Vector3.zero)
            {
                velocityU -= new Vector3(0, (float)speed) * Time.deltaTime;
                if (!hitBorderU)
                {
                    this.transform.position += velocityU;
                }
            }
        }

    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "BorderLeft" && !hitBorderL)
        {
            coldist = this.gameObject.GetComponent<Collider2D>().Distance(col);
            this.transform.position -= new Vector3((float)(coldist.distance), 0);
            velocityL = Vector3.zero;
            hitBorderL = true;
        }

        if (col.gameObject.tag == "BorderRight")
        {
            coldist = this.gameObject.GetComponent<Collider2D>().Distance(col);
            this.transform.position += new Vector3((float)(coldist.distance), 0);
            velocityR = Vector3.zero;
            hitBorderR = true;
        }

        if (col.gameObject.tag == "BorderUp")
        {
            coldist = this.gameObject.GetComponent<Collider2D>().Distance(col);
            this.transform.position += new Vector3(0, (float)(coldist.distance));
            velocityU = Vector3.zero;
            hitBorderU = true;
        }

        if (col.gameObject.tag == "BorderDown")
        {
            coldist = this.gameObject.GetComponent<Collider2D>().Distance(col);
            this.transform.position -= new Vector3(0, (float)(coldist.distance));
            velocityD = Vector3.zero;
            hitBorderD = true;
        }

        if (col.gameObject.tag == "EnemyPlane")
        {
            if (health == 0)
            {
                Destroy(this.gameObject);
            }
            Debug.Log(health);
        }

        if (col.gameObject.tag == "Upgrade")
        {
            
        }
    }

    void OnTriggerExit2D(Collider2D col) 
    {
        if (col.gameObject.tag == "BorderLeft")
        {
            hitBorderL = false;
        }

        if (col.gameObject.tag == "BorderRight")
        {
            hitBorderR = false;
        }

        if (col.gameObject.tag == "BorderUp")
        {
            hitBorderU = false;
        }

        if (col.gameObject.tag == "BorderDown")
        {
            hitBorderD = false;
        }
    }
}
