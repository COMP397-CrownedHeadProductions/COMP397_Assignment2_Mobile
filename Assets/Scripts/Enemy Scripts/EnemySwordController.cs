using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwordController : MonoBehaviour
{
    public Rigidbody rb;
    int damage;
    public int damageRange1;
    public int damageRange2;

    public PlayerController playerDamage;
    public HealthBarController healthBar;

    // Start is called before the first frame update
    void Start()
    {
        playerDamage = GameObject.Find("Player").GetComponent<PlayerController>();
        healthBar = GameObject.Find("Health_Bar").GetComponent<HealthBarController>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        damage = Random.Range(damageRange1, damageRange2);
        if (collision.gameObject.tag == "Player")
        {
            playerDamage.DamageHealth(damage);
            healthBar.TakeDamage(damage);
            Debug.Log("Knight dealt " + damage + " to Player.");
        }
    }
}
