using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Source File: Quest2AlertController.cs
 * Editors: Timothy Garcia
 * Student Number: 300898955
 * Date Modified: 04-13-2021
 * Program: 3109 - Game-Programming(Optional Co-op)
 * 
 * --------------------Revision History--------------------
 *                 Final Release - 2021.04.13
 * - Implemented function and UI for "Quest 2 Completed" notification
 */

public class Quest2AlertController : MonoBehaviour
{
    public Vector2 offScreenPos;
    public Vector2 onScreenPos;
    [Range(0.1f, 10.0f)]
    public float speed = 1.0f;
    public float timer = 0.0f;
    public bool questCompleted = false;
    public bool isOnScreen = false;

    [Header("Quest 2 Alert Canvas Properties")]
    public RectTransform quest2RectTransform;

    [Header("Quest Properties Canvas")]
    public EnemyManager enemyManager;

    // Start is called before the first frame update
    void Start()
    {
        enemyManager = GameObject.Find("Enemies").GetComponent<EnemyManager>();
        quest2RectTransform = GameObject.Find("Quest2AlertUI").GetComponent<RectTransform>();
        quest2RectTransform.anchoredPosition = offScreenPos;
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyManager.chaseEnemyCount == enemyManager.chaseEnemyTotal && enemyManager.rangeEnemyCount == enemyManager.rangeEnemyTotal)
        {
            Quest2PanelOn();
            Destroy(gameObject, 10.0f);
        }
    }

    private void Quest2PanelOn()
    {
        quest2RectTransform.anchoredPosition = Vector2.Lerp(offScreenPos, onScreenPos, timer);
        if (timer < 1.0f)
        {
            timer += Time.deltaTime * speed;
        }
    }

    public void Quest2PanelOff()
    {
        enemyManager.chaseEnemyCount -= 0.01f;
        enemyManager.rangeEnemyCount -= 0.01f;
        isOnScreen = false;
        quest2RectTransform.anchoredPosition = Vector2.Lerp(onScreenPos, offScreenPos, timer);
        if (timer < 1.0f)
        {
            timer += Time.deltaTime * speed;
        }
    }
}
