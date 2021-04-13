using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Source File: QuestAlertController.cs
 * Editors: Timothy Garcia
 * Student Number: 300898955
 * Date Modified: 04-13-2021
 * Program: 3109 - Game-Programming(Optional Co-op)
 * 
 * --------------------Revision History--------------------
 *                 Final Release - 2021.04.13
 * - Implemented function and UI for "Quest 1 Completed" notification
 */

public class QuestAlertController : MonoBehaviour
{
    public Vector2 offScreenPos;
    public Vector2 onScreenPos;
    [Range(0.1f, 10.0f)]
    public float speed = 1.0f;
    public float timer = 0.0f;
    public bool questCompleted = false;
    public bool isOnScreen = false;

    [Header("Quest 1 Alert Canvas Properties")]
    public RectTransform quest1RectTransform;
    
    [Header("Quest Properties Canvas")]
    public KeyManager keyManager;

    // Start is called before the first frame update
    void Start()
    {
        keyManager = GameObject.Find("Keys").GetComponent<KeyManager>();
        quest1RectTransform = GameObject.Find("Quest1AlertUI").GetComponent<RectTransform>();
        quest1RectTransform.anchoredPosition = offScreenPos;
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (keyManager.keyCount == keyManager.keyTotal)
        {
            Quest1PanelOn();
            Destroy(gameObject, 10.0f);
        }
    }

    private void Quest1PanelOn()
    {
        quest1RectTransform.anchoredPosition = Vector2.Lerp(offScreenPos, onScreenPos, timer);
        if (timer < 1.0f)
        {
            timer += Time.deltaTime * speed;
        }
    }

    public void Quest1PanelOff()
    {
        keyManager.keyCount -= 0.01f;
        isOnScreen = false;
        quest1RectTransform.anchoredPosition = Vector2.Lerp(onScreenPos, offScreenPos, timer);
        if (timer < 1.0f)
        {
            timer += Time.deltaTime * speed;
        }
    }
}
