using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Source File: KeyManager.cs
 * Editors: Timothy Garcia
 * Student Number: 300898955
 * Date Modified: 04-12-2021
 * Program: 3109 - Game-Programming(Optional Co-op)
 * 
 * --------------------Revision History--------------------
 * 
 *             Final Release - 2021.04.12
 * - Implemented function and UI for collecting all keys quest
 *
 */

public class KeyManager : MonoBehaviour
{
    public Text keyText;
    public float keyCount;
    public int keyTotal;
    public GameObject exitStar;
    public Image checkMark1;

    // Start is called before the first frame update
    void Start()
    {
        exitStar = GameObject.Find("ExitStar").GetComponent<GameObject>();
        checkMark1 = GameObject.Find("CheckMark1").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        keyText.text = keyCount.ToString("0") + "/" + keyTotal.ToString();
        if (keyCount >= keyTotal)
        {
            exitStar.SetActive(true);
            checkMark1.gameObject.SetActive(true);
        }
        //if (keyCount >= 1)
        //{
        //    keyAudioSource.clip = keyPickupAudio;
        //    keyAudioSource.Play();
        //}
    }
}
