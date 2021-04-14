using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * Source File: ExitStarController.cs
 * Editors: Timothy Garcia
 * Student Number: 300898955
 * Date Modified: 04-13-2021
 * Program: 3109 - Game-Programming(Optional Co-op)
 * 
 * --------------------Revision History--------------------
 * 
 *             Final Release - 2021.04.12
 * - Implemented function to open "Level Complete" canvas once player has finished the level.
 * - 
 */

public class ExitStarController : MonoBehaviour
{
    public KeyManager keyItem;
    public EnemyManager enemyManager;
    public SuperHeartManager superHeartItem;
    public Text questCountTxt;
    public int questCount;
    public int questTotal;
    public GameObject levelCompleteCanvas;

    // Start is called before the first frame update
    void Start()
    {
        keyItem = GameObject.Find("Keys").GetComponent<KeyManager>();
        enemyManager = GameObject.Find("Enemies").GetComponent<EnemyManager>();
        superHeartItem = GameObject.Find("SuperHearts").GetComponent<SuperHeartManager>();
    }

    // Update is called once per frame
    void Update()
    {
        questCountTxt.text = questCount + "/" + questTotal;
        if(keyItem.keyCount > 2.5)
        {
            questCount = 1;
        }
        if (keyItem.keyCount > 2.5 && (enemyManager.rangeEnemyCount > 8.5 && enemyManager.chaseEnemyCount > 2.5))
        {
            questCount = 2;
        }
        if (keyItem.keyCount > 2.5 && superHeartItem.superHeartCount > 2.5)
        {
            questCount = 2;
        }
        if (keyItem.keyCount > 2.5 && enemyManager.rangeEnemyCount > 8.5 && enemyManager.chaseEnemyCount > 2.5 && superHeartItem.superHeartCount > 2.5)
        {
            questCount = 3;
        }

        if (questCount == 1)
        {
            questCountTxt.color = Color.red;
        }
        if (questCount == 2)
        {
            questCountTxt.color = Color.yellow;
        }
        if (questCount == 3)
        {
            questCountTxt.color = Color.green;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Time.timeScale = 0f;
            levelCompleteCanvas.SetActive(!levelCompleteCanvas.activeInHierarchy);
        }
    }
}
