using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * Source File: RestartManager.cs
 * Editors: Timothy Garcia
 * Student Number: 300898955
 * Date Modified: 03-19-2021
 * Program: 3109 - Game-Programming(Optional Co-op)
 * 
 * --------------------Revision History--------------------
 *                        Beta - 2021-03-21
 * - Deathscreen UI added
 * - 
 */

public class CountdownController : MonoBehaviour
{
    public GameObject deathScreenUI;
    public float countdown = 0.0f;
    public float startingCountdown = 5.0f;
    public Text countDownTxt;
    public Text countDownTxt1;

    // Start is called before the first frame update
    void Start()
    {
        countdown = startingCountdown;
        deathScreenUI.SetActive(!deathScreenUI.activeInHierarchy);
    }

    // Update is called once per frame
    void Update()
    {
        //deathScreenUI.SetActive(!deathScreenUI.activeInHierarchy);
        countdown -= 1 * Time.deltaTime;
        countDownTxt.text = countdown.ToString("0");
        countDownTxt1.text = countdown.ToString("0");
        if(countdown < 0)
        {
            Invoke("RestartScene", 0.0f);
        }
    }

    void RestartScene()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(2);
    }
}
