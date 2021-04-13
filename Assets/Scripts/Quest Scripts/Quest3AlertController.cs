using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Source File: Quest3AlertController.cs
 * Editors: Timothy Garcia
 * Student Number: 300898955
 * Date Modified: 04-13-2021
 * Program: 3109 - Game-Programming(Optional Co-op)
 * 
 * --------------------Revision History--------------------
 *                 Final Release - 2021.04.13
 * - Implemented function and UI for "Quest 3 Completed" notification
 */

public class Quest3AlertController : MonoBehaviour
{
    public Vector2 offScreenPos;
    public Vector2 onScreenPos;
    [Range(0.1f, 10.0f)]
    public float speed = 1.0f;
    public float timer = 0.0f;
    public bool questCompleted = false;
    public bool isOnScreen = false;

    [Header("Quest 3 Alert Canvas Properties")]
    public RectTransform quest3RectTransform;

    [Header("Quest Properties Canvas")]
    public SuperHeartManager superHeartManager;

    // Start is called before the first frame update
    void Start()
    {
        superHeartManager = GameObject.Find("SuperHearts").GetComponent<SuperHeartManager>();
        quest3RectTransform = GameObject.Find("Quest3AlertUI").GetComponent<RectTransform>();
        quest3RectTransform.anchoredPosition = offScreenPos;
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (superHeartManager.superHeartCount == superHeartManager.superHeartTotal)
        {
            Quest3PanelOn();
            Destroy(gameObject, 10.0f);
        }
    }

    private void Quest3PanelOn()
    {
        quest3RectTransform.anchoredPosition = Vector2.Lerp(offScreenPos, onScreenPos, timer);
        if (timer < 1.0f)
        {
            timer += Time.deltaTime * speed;
        }
    }

    public void Quest3PanelOff()
    {
        superHeartManager.superHeartCount -= 0.01f;
        isOnScreen = false;
        quest3RectTransform.anchoredPosition = Vector2.Lerp(onScreenPos, offScreenPos, timer);
        if (timer < 1.0f)
        {
            timer += Time.deltaTime * speed;
        }
    }
}
