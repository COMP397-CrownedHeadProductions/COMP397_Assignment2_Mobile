using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
 * Source File: HeartDropController.cs
 * Editors: Timothy Garcia
 * Student Number: 300898955
 * Date Modified: 02-16-2021
 * Program: 3109 - Game-Programming(Optional Co-op)
 * 
 * --------------------Revision History--------------------
 *                   Pre-Alpha - 2021.02.14
 * - Heart animation movement and rotation added
 * - Heart function to add health to player
 * 
 *                       Alpha - 2021-03-08
 * - Max Health Increase functionality
 * - Max Health game object created
 * 
 *                        Beta - 2021-03-21
 * - 
 */

public class HeartDropController : MonoBehaviour {

    public int healthAmount;

    public bool isAnimated = false;

    //Heart movement varialbes
    public bool isRotating = false;
    public bool isFloating = false;
    public bool isScaling = false;

    //Rotation variables
    public Vector3 rotationAngle;
    public float rotationSpeed;

    //Float variables
    public float floatSpeed;
    private bool goingUp = true;
    public float floatRate;
    private float floatTimer;
   
    //Scaling change variables
    public Vector3 startScale;
    public Vector3 endScale;

    private bool scalingUp = true;
    public float scaleSpeed;
    public float scaleRate;
    private float scaleTimer;

    public bool isSuperHealth;
    public int superHealth;

    public HealthBarController healthBar;
    public HealthBarController healthSlider;

    // Use this for initialization
    void Start () 
    {
        healthBar = GameObject.Find("Health_Bar").GetComponent<HealthBarController>();
    }
	
	// Update is called once per frame
	void Update () 
    {
        if(isAnimated)
        {
            if(isRotating)
            {
                transform.Rotate(rotationAngle * rotationSpeed * Time.deltaTime);
            }

            if(isFloating)
            {
                floatTimer += Time.deltaTime;
                Vector3 moveDir = new Vector3(0.0f, 0.0f, floatSpeed);
                transform.Translate(moveDir);

                if (goingUp && floatTimer >= floatRate)
                {
                    goingUp = false;
                    floatTimer = 0;
                    floatSpeed = -floatSpeed;
                }

                else if(!goingUp && floatTimer >= floatRate)
                {
                    goingUp = true;
                    floatTimer = 0;
                    floatSpeed = +floatSpeed;
                }
            }

            if(isScaling)
            {
                scaleTimer += Time.deltaTime;

                if (scalingUp)
                {
                    transform.localScale = Vector3.Lerp(transform.localScale, endScale, scaleSpeed * Time.deltaTime);
                }
                else if (!scalingUp)
                {
                    transform.localScale = Vector3.Lerp(transform.localScale, startScale, scaleSpeed * Time.deltaTime);
                }

                if(scaleTimer >= scaleRate)
                {
                    if (scalingUp) { scalingUp = false; }
                    else if (!scalingUp) { scalingUp = true; }
                    scaleTimer = 0;
                }
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerController health = other.gameObject.GetComponent<PlayerController>();
            health.currentHealth += healthAmount;
            healthBar.TakeDamage(-healthAmount);
            gameObject.SetActive(false);
            if (health.currentHealth > health.maxHealth)
            {
                health.currentHealth = health.maxHealth;
            }
            Debug.Log("Player gained " + healthAmount + " health");
        }
        if(other.tag == "Player" && isSuperHealth == true)
        {
            PlayerController health = other.gameObject.GetComponent<PlayerController>();
            health.maxHealth += superHealth;
            health.currentHealth = health.maxHealth;
            healthBar.TakeDamage(-healthAmount);
            healthBar.maximumHealth += superHealth;
            healthBar.GetComponent<HealthBarController>().GetComponent<Slider>().value += superHealth; 
            Destroy(gameObject);
            Debug.Log("Maximum Health increased!");
        }
    }
}
