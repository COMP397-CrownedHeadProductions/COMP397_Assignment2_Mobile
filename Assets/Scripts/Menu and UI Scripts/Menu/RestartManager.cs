using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


/*
 * Source File: RestartManager.cs
 * Editors: Timothy Garcia
 * Student Number: 300898955
 * Date Modified: 03-19-2021
 * Program: 3109 - Game-Programming(Optional Co-op)
 * 
 * --------------------Revision History--------------------
 *                   Pre-Alpha - 2021.02.14
 * - Restart Scene function
 *
 *                        Beta - 2021-03-21
 * - Deathscreen UI functionality implemented
 * - 
 */

public class RestartManager : MonoBehaviour
{
    public GameObject countdownControl;
    public GameObject playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            countdownControl.SetActive(!countdownControl.activeInHierarchy);
            Destroy(other.gameObject);
        }
    }
}
