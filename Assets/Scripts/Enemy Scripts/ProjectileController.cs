using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * Source File: ProjectileController.cs
 * Editors: Timothy Garcia
 * Student Number: 300898955
 * Date Modified: 02-16-2021
 * Program: 3109 - Game-Programming(Optional Co-op)
 * 
 * --------------------Revision History--------------------
 *                   Pre-Alpha - 2021.02.14
 * - Projectile for ranged enemy implemented(WIP)
 * - Damage to player functional
 * - Game object destroyed when it collides with player or wall
 */

public class ProjectileController : MonoBehaviour
{
    public Rigidbody rb;
    private GameObject player;
    public Transform playerBody;
    int damage;
    public int damageRange1;
    public int damageRange2;

    public PlayerController playerDamage;
    public HealthBarController healthBar;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        playerDamage = GameObject.Find("Player").GetComponent<PlayerController>();
        healthBar = GameObject.Find("Health_Bar").GetComponent <HealthBarController>();
        transform.LookAt(playerBody);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnCollisionEnter(Collision collision)
    {
        damage = Random.Range(damageRange1, damageRange2);
        if(collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Projectile")
        {
            Destroy(gameObject);
            Debug.Log("Projectile collided with Wall");
        }
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
            Debug.Log("Projectile collided with Ground");
        }
        if (collision.gameObject.tag == "PlayerSword")
        {
            Destroy(gameObject);
            Debug.Log("Projectile collided with Sword");
        }
        if (collision.gameObject.tag == "Player")
        {
            //collision.gameObject.GetComponent<PlayerController>().currentHealth -= damage;
            playerDamage.DamageHealth(damage);
            healthBar.TakeDamage(damage);
            Destroy(gameObject);
            Debug.Log("Enemy dealt " + damage + " damage to Player");
        }
    }
}
