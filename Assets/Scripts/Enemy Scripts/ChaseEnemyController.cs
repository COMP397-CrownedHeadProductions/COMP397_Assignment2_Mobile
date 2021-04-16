using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
 * Source File: ChaseEnemyController.cs
 * Editors: Timothy Garcia
 * Student Number: 300898955
 * Date Modified: 04-16-2021
 * Program: 3109 - Game-Programming(Optional Co-op)
 * 
 * --------------------Revision History--------------------
 *                   Pre-Alpha - 2021.02.14
 * - Basic enemy movement and animation implemented
 * - Enemy AI functions implemented (Patrol, Chase and Attack player functions)
 * - Health drop variables added
 * 
 *                 Final Release - 2021.04.12
 * - Implemented function and UI for destroying all enemies (optional quest)
 * - 
 */

public class ChaseEnemyController : MonoBehaviour
{
    public EnemyManager enemyManager;

    public NavMeshAgent navMeshAgent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public float health = 100;
    public float maxHealth;
    public GameObject healthDrop;
    public bool dropsHealth;

    public Animator animator;
    public GameObject heartPickup;
    public Transform heartSpawn;

    //Patrol Variables
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attack Variable
    public float attackDelay;
    bool attackActive;
    public GameObject enemyProjectile;
    public Transform shootPoint;
    public float projectileSpeed;

    //State Variables
    public float sightRange, attackRange;
    public bool inSightRange, inAttackRange;

    // Start is called before the first frame update
    private void Awake()
    {
        enemyManager = GameObject.Find("Enemies").GetComponent<EnemyManager>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        health = maxHealth;
    }

    // Update is called once per frame
    private void Update()
    {
        //Checks for sight and attack range from player
        inSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        inAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!inSightRange && !inAttackRange)
        {
            Patrol();
            animator.SetBool("inRange", false);
        }
        if (inSightRange && !inAttackRange)
        {
            Chase();
            animator.SetBool("inRange", true);
            animator.SetBool("attackRange", false);
        }
        if (inSightRange && inAttackRange) 
        { 
            Attack();
            animator.SetBool("attackRange", true);
        }

        animator.SetFloat("Speed", navMeshAgent.speed);
        EnemyDead();
    }

    //Moves to a set position after a certain distance
    private void Patrol()
    {
        //Debug.Log("Patrolling....");
        if (!walkPointSet) SearchWalkPoint();
        if (walkPointSet)
            navMeshAgent.SetDestination(walkPoint);

        Vector3 walkPointDistance = transform.position - walkPoint;

        //Walkpoint range limit
        if (walkPointDistance.magnitude < 1f)
            walkPointSet = false;

        navMeshAgent.speed = 3;
    }

    //Sets the enemy set point position.
    private void SearchWalkPoint()
    {
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    //Chase Player Function - When player is in a certain range
    private void Chase()
    {
        //Debug.Log("Chasing Player");
        navMeshAgent.SetDestination(player.position);
        navMeshAgent.speed = 4;
    }

    //Attacks Player Function
    private void Attack()
    {
        //Debug.Log("Attacking Player");
        navMeshAgent.SetDestination(transform.position);
        transform.LookAt(player);
        if (!attackActive)
        {
            //Rigidbody rb = Instantiate(enemyProjectile, shootPoint.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            //rb.AddForce(transform.forward * projectileSpeed, ForceMode.Impulse);
            //attackActive = true;
            //Invoke(nameof(ResetAttack), attackDelay);
            GameObject projectile = ProjectileObjectPool.SharedInstance.GetPooledObject();
            if (projectile != null)
            {
                projectile.transform.position = shootPoint.transform.position;
                projectile.transform.rotation = shootPoint.transform.rotation;
                projectile.SetActive(true);
            }
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * projectileSpeed, ForceMode.Impulse);
            attackActive = true;
            Invoke(nameof(ResetAttack), attackDelay);
        }
    }

    private void ResetAttack()
    {
        attackActive = false;
    }

    public void EnemyDead()
    {
        if (health <= 0)
        {
            enemyManager.chaseEnemyCount++;
            HealthDrop();
            Destroy(gameObject);
        }
    }
    void HealthDrop()
    {
        if (dropsHealth)
        {
            //heartPickup = Instantiate(healthDrop, heartSpawn.transform.position, transform.rotation);
            //heartPickup.transform.Rotate(-90.0f, 0.0f, 0.0f);
            GameObject heartPickup = HeartObjectPool.SharedInstance.GetPooledObject();
            if (heartPickup != null)
            {
                heartPickup.transform.position = heartSpawn.transform.position;
                heartPickup.transform.rotation = Quaternion.Euler(-90.0f, 0.0f, 0.0f);
                heartPickup.SetActive(true);
            }
        }
    }
}
