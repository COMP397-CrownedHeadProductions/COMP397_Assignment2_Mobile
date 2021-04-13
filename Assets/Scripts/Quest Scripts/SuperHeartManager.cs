using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Source File: SuperHeartManager.cs
 * Editors: Timothy Garcia
 * Student Number: 300898955
 * Date Modified: 04-12-2021
 * Program: 3109 - Game-Programming(Optional Co-op)
 * 
 * --------------------Revision History--------------------
 * 
 *             Final Release - 2021.04.12
 * - Implemented function and UI for collecting all super hearts (optional quest)
 * - 
 */

public class SuperHeartManager : MonoBehaviour
{
    public Text superHeartText;
    public float superHeartCount;
    public int superHeartTotal;
    public Image checkMark3;

    // Start is called before the first frame update
    void Start()
    {
        checkMark3 = GameObject.Find("CheckMark2").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        superHeartText.text = superHeartCount.ToString("0") + "/" + superHeartTotal.ToString();
        if (superHeartCount >= superHeartTotal)
        {
            checkMark3.gameObject.SetActive(true);
        }
    }
}
