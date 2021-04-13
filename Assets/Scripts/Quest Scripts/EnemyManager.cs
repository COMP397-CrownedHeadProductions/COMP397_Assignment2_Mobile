using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Source File: EnemyManager.cs
 * Editors: Timothy Garcia
 * Student Number: 300898955
 * Date Modified: 04-12-2021
 * Program: 3109 - Game-Programming(Optional Co-op)
 * 
 * --------------------Revision History--------------------
 * 
 *             Final Release - 2021.04.12
 * - Implemented function and UI for destroying all enemies (optional quest)
 * - 
 */
public class EnemyManager : MonoBehaviour
{
    public Image checkMark2;

    [Header("Chase Enemy Count")]
    public Text chaseEnemyCountText;
    public float chaseEnemyCount;
    public int chaseEnemyTotal;

    [Header("Range Enemy Count")]
    public Text rangeEnemyCountText;
    public float rangeEnemyCount;
    public int rangeEnemyTotal;

    // Start is called before the first frame update
    void Start()
    {
        checkMark2 = GameObject.Find("CheckMark2").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        chaseEnemyCountText.text = chaseEnemyCount.ToString("0") + "/" + chaseEnemyTotal.ToString();
        rangeEnemyCountText.text = rangeEnemyCount.ToString("0") + "/" + rangeEnemyTotal.ToString();
        if (rangeEnemyCount >= rangeEnemyTotal && chaseEnemyCount >= chaseEnemyTotal)
        {
            checkMark2.gameObject.SetActive(true);
        }
    }
}
