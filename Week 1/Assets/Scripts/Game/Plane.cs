using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour {

    private float speed = 0.1f;
    public int initHealth = 5;
    public int currentHealth;
    public int initArmor = 0;
    public int currentArmor;

    private Vector3 velocityU = new Vector3(0, 0);
    private Vector3 velocityD = new Vector3(0, 0);
    private Vector3 velocityL = new Vector3(0, 0);
    private Vector3 velocityR = new Vector3(0, 0);
    public bool hitBorderU = false;
    public bool hitBorderD = false;
    public bool hitBorderL = false;
    public bool hitBorderR = false;
    
    private ColliderDistance2D coldist;

    float shootingDelayTimer = 0;
    float shootingDelay = 1f;
    public GameObject MISSILE;
    public Transform firepos;

    private bool isExploded;
    public Animator animator;

    // Use this for initialization
    void Start () {
        currentHealth = initHealth;
        currentArmor = initArmor;
        isExploded = false;
	}
	
	// Update is called once per frame
	void Update () {
        InputHandle();

        shootingDelayTimer += Time.deltaTime;
        if (shootingDelayTimer >= shootingDelay && Input.GetKeyDown(KeyCode.C) && !isExploded)
        {
            shootingDelayTimer = 0;
            if (Input.GetKeyDown(KeyCode.C))
            {
                Instantiate(MISSILE, firepos.position, Quaternion.identity);
            }
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "BorderLeft")
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

    void InputHandle()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && !isExploded)
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

        if (Input.GetKey(KeyCode.RightArrow) && !isExploded)
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

        if (Input.GetKey(KeyCode.DownArrow) && !isExploded)
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

        if (Input.GetKey(KeyCode.UpArrow) && !isExploded)
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

    public void TakeDamage(int damage)
    {
        int damageAfterArmor = damage - currentArmor;
        if (damageAfterArmor > 0)
        {
            currentArmor = 0;
            currentHealth -= damageAfterArmor;
            if (currentHealth <= 0)
                OnExplode();
        }
        else
            currentArmor -= damage;
    }

    public void LootHealth(int health)
    {
        currentHealth += health;
        if (currentHealth >= initHealth)
            currentHealth = initHealth;
    }

    public void LootArmor(int armor)
    {
        currentArmor += armor;
    }

    public void UpgradeHealth(int health)
    {
        initHealth += health;
    }

    public void OnExplode()
    {
        isExploded = true;
        animator.SetBool("isExploded", isExploded);
        gameObject.GetComponent<Collider2D>().enabled = false;
        if (gameObject.GetComponent<ShootManager>() != null)
            gameObject.GetComponent<ShootManager>().enabled = false;
        Destroy(gameObject, 1);
    }
    
}
